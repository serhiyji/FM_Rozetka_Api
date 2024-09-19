using FM_Rozetka_Api.Core.DTOs;
using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using FM_Rozetka_Api.Core.DTOs.Orders.Shipment;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rozetka_Api.Core.Entities;
using System.Text;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly LiqPayService _liqPayService;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;
        private readonly IProductService _productService;
        private readonly IOrderStatusHistoryService _orderStatusHistoryService;
        private readonly IShipmentService _shipmentService;
        private readonly INovaPoshtaService _novaPoshtaService;


        private readonly string _encryptionKey;

        public PaymentController(IPaymentService paymentService, IConfiguration configuration, LiqPayService liqPayService,
            IOrderService orderService, IOrderItemService orderItemService, ICartItemService cartItemService, IProductService productService,
            IOrderStatusHistoryService orderStatusHistoryService, IShipmentService shipmentService, INovaPoshtaService novaPoshtaService)
        {
            _paymentService = paymentService;
            _liqPayService = liqPayService;
            _encryptionKey = configuration["Encryption:Key"];
            _orderService = orderService;
            _orderItemService = orderItemService;
            _cartItemService = cartItemService;
            _productService = productService;
            _orderStatusHistoryService = orderStatusHistoryService;
            _shipmentService = shipmentService;
            _novaPoshtaService = novaPoshtaService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] PaymentCreateDTO model)
        {
            var response = await _paymentService.AddAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] PaymentUpdateDTO model)
        {
            var response = await _paymentService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _paymentService.DeleteAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _paymentService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _paymentService.GetByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("create-payment-link")]
        public async Task<IActionResult> CreatePaymentLink([FromBody] PaymentLinkCreateDTO model)
        {
            var response = await _liqPayService.CreatePaymentLink(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("callback")]
        public async Task<IActionResult> PaymentCallback([FromForm] string data, [FromForm] string signature, [FromQuery] string encrypted_cart, [FromQuery] string encrypted_customer)
        {
            try
            {
                Console.WriteLine("encrypted_cart " + encrypted_cart);
                Console.WriteLine("encrypted_customer " + encrypted_customer);

                if (!_liqPayService.VerifySignature(data, signature))
                {
                    Console.WriteLine("Invalid signature");
                    return BadRequest("Invalid signature");
                }

                var decodedData = Encoding.UTF8.GetString(Convert.FromBase64String(data));
                dynamic paymentInfo = Newtonsoft.Json.Linq.JObject.Parse(decodedData);
                Console.WriteLine($"Payment info: {decodedData}");

                var decryptedCart = encrypted_cart;
                var decryptedCustomer = JsonConvert.DeserializeObject<CustomerInfoDTO>(encrypted_customer);

                Console.WriteLine($"Decrypted cart: {decryptedCart}");
                Console.WriteLine($"Decrypted customer: {JsonConvert.SerializeObject(decryptedCustomer)}");


                if (paymentInfo.status == "success" || paymentInfo.status == "sandbox")
                {
                    Console.WriteLine($"Payment status: {paymentInfo.status}. Order ID: {paymentInfo.order_id}");

                    try
                    {
                        var orderIds = decryptedCart.Split('|').Select(id => int.Parse(id)).ToArray();
                        var response = await _cartItemService.GetByIds(orderIds);

                        if (!response.Success)
                        {
                            Console.WriteLine($"Failed to get cart items. Order ID: {paymentInfo.order_id}. Error: {response.Message}");
                            return BadRequest("Failed to get cart items.");
                        }

                        var cartItems = response.Payload;
                        var appUserId = cartItems.First().AppUserId;
                        var appProductIds = cartItems.Select(cartItem => cartItem.ProductId).ToArray();
                        var products = new List<ProductDTO>();

                        foreach (var productId in appProductIds)
                        {
                            var productResponse = await _productService.GetByIdAsync(productId);
                            if (!productResponse.Success)
                            {
                                Console.WriteLine($"Failed to get product. Product ID: {productId}. Error: {productResponse.Message}");
                                continue;
                            }

                            products.Add(productResponse.Payload);
                        }

                        //UpdateProduct
                        foreach (var cartItem in cartItems)
                        {
                            var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);

                            if (product != null)
                            {
                                var updatedStock = product.Stock - cartItem.Quantity;
                                if (updatedStock < 0)
                                {
                                    Console.WriteLine($"Insufficient stock for product ID: {product.Id}. Available: {product.Stock}, Requested: {cartItem.Quantity}");
                                    return BadRequest($"Insufficient stock for product: {product.Name}");
                                }

                                var productUpdateDTO = new ProductUpdateDTO
                                {
                                    Id = product.Id,
                                    Name = product.Name,
                                    Description = product.Description,
                                    Price = product.Price,
                                    Stars = product.Stars,
                                    Stock = updatedStock,
                                    BrandId = product.BrandId,
                                    CreatedAt = product.CreatedAt,
                                    ShopId = product.ShopId,
                                    HasDiscount = product.HasDiscount,
                                    CategoryProductId = product.CategoryProductId,
                                    CountryProductionId = product.CountryProductionId,
                                };

                                var updateResponse = await _productService.UpdateAsync(productUpdateDTO);
                                if (!updateResponse.Success)
                                {
                                    Console.WriteLine($"Failed to update stock for product ID: {product.Id}. Error: {updateResponse.Message}");
                                    return BadRequest($"Failed to update stock for product: {product.Name}");
                                }
                            }
                        }

                        // Order
                        var order = new OrderCreateDTO
                        {
                            AppUserId = appUserId,
                            OrderDate = DateTime.UtcNow,
                            Status = "Pending",
                            TotalAmount = paymentInfo.amount,
                            OrderId = paymentInfo.order_id
                        };

                        var createdOrderResponse = await _orderService.AddAsync(order);
                        if (!createdOrderResponse.Success)
                        {
                            Console.WriteLine($"Failed to create order. Error: {createdOrderResponse.Message}");
                            return BadRequest("Failed to create order.");
                        }

                        var orderId = createdOrderResponse.Payload.Id;
                        Console.WriteLine($"Order created successfully. Order ID: {orderId}");

                        // OrderItem
                       

                        var orderItems = cartItems.Select(cartItem =>
                        {
                            var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                            if (product == null)
                            {
                                Console.WriteLine($"Product not found for cart item. Product ID: {cartItem.ProductId}");
                                return null;
                            }

                            return new OrderItemCreateDTO
                            {
                                OrderId = orderId,
                                ProductId = cartItem.ProductId,
                                Quantity = cartItem.Quantity,
                                Price = product.Price
                            };
                        }).Where(oi => oi != null).ToList();

                        foreach (var orderItem in orderItems)
                        {
                            var orderItemResponse = await _orderItemService.AddAsync(orderItem);
                            if (!orderItemResponse.Success)
                            {
                                Console.WriteLine($"Failed to add order item. Order ID: {orderId}. Product ID: {orderItem.ProductId}. Error: {orderItemResponse.Message}");
                            }
                        }

                        // OrderStatusHistory
                        var orderStatusHistory = new OrderStatusHistoryCreateDTO
                        {
                            OrderId = orderId,
                            Status = "Pending",
                            ChangedAt = DateTime.UtcNow
                        };

                        var orderStatusHistoryResponse = await _orderStatusHistoryService.AddAsync(orderStatusHistory);
                        if (!orderStatusHistoryResponse.Success)
                        {
                            Console.WriteLine($"Failed to create order status history. Order ID: {orderId}. Error: {orderStatusHistoryResponse.Message}");
                        }

                        // Payment
                        var payment = new PaymentCreateDTO
                        {
                            OrderId = orderId,
                            PaymentMethod = "card" + paymentInfo.sender_card_mask2,
                            PaymentDate = DateTime.UtcNow,
                            Amount = paymentInfo.amount,
                            Status = "Success"
                        };

                        var paymentResponse = await _paymentService.AddAsync(payment);
                        if (!paymentResponse.Success)
                        {
                            Console.WriteLine($"Failed to create payment record. Order ID: {orderId}. Error: {paymentResponse.Message}");
                            return BadRequest("Failed to create payment record.");
                        }

                        var area = await _novaPoshtaService.GetByIdArea(decryptedCustomer.Region);
                        var settlement = await _novaPoshtaService.GetByIdSettlements(decryptedCustomer.City);
                        var warehouse = await _novaPoshtaService.GetByIdWarehouses(decryptedCustomer.PickupPoint);

                        // Додавання інформації про доставку
                        var shipment = new ShipmentCreateDTO
                        {
                            OrderId = orderId,
                            ShipmentDate = DateTime.UtcNow,
                            TrackingNumber = "None",
                            Carrier = "Nova Poshta",
                            Status = "Shipped",
                            Name = decryptedCustomer.Name,
                            SurName = decryptedCustomer.Surname,
                            PhoneNumber = decryptedCustomer.Phone,
                            Email = decryptedCustomer.Email,
                            Region = area.Payload.Description,
                            City = settlement.Payload.Description,
                            PickupPoint = warehouse.Payload.Description
                        };

                        var shipmentResponse = await _shipmentService.AddAsync(shipment);
                        if (!shipmentResponse.Success)
                        {
                            Console.WriteLine($"Failed to create shipment record. Order ID: {orderId}. Error: {shipmentResponse.Message}");
                            return BadRequest("Failed to create shipment record.");
                        }

                        // Delete cart items
                        foreach (var item in cartItems)
                        {
                            try
                            {
                                var deleteResponse = await _cartItemService.Delete(item.Id);
                                if (!deleteResponse.Success)
                                {
                                    Console.WriteLine($"Failed to delete cart item. CartItem ID: {item.Id}. Error: {deleteResponse.Message}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error deleting cart item with ID: {item.Id}. Exception: {ex.Message}");
                                return BadRequest($"Error deleting cart item with ID: {item.Id}");
                            }
                        }

                        Console.WriteLine($"Payment recorded successfully. Order ID: {orderId}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception occurred: {ex.Message}");
                        return StatusCode(500, "An error occurred while processing the payment callback.");
                    }
                }
                else if (paymentInfo.status == "failure")
                {
                    Console.WriteLine($"Payment failed. Order ID: {paymentInfo.order_id}");
                }
                else
                {
                    Console.WriteLine($"Unknown payment status: {paymentInfo.status}. Order ID: {paymentInfo.order_id}");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return BadRequest("An error occurred while processing the payment callback.");
            }
        }

        [HttpPost("create-payment-cash")]
        public async Task<IActionResult> CreatePaymentCashAsync([FromForm] PaymentCashDTO model)
        {
            try
            {
                var response = await _cartItemService.GetByIds(model.CartItemIds.ToArray());

                if (!response.Success)
                {
                    Console.WriteLine($"Failed to get cart items. Error: {response.Message}");
                    return BadRequest("Failed to get cart items.");
                }
                var temporaryOrderId = Guid.NewGuid().ToString();
                var cartItems = response.Payload;
                var appUserId = cartItems.First().AppUserId;
                var appProductIds = cartItems.Select(cartItem => cartItem.ProductId).ToArray();
                var products = new List<ProductDTO>();

                foreach (var productId in appProductIds)
                {
                    var productResponse = await _productService.GetByIdAsync(productId);
                    if (!productResponse.Success)
                    {
                        Console.WriteLine($"Failed to get product. Product ID: {productId}. Error: {productResponse.Message}");
                        continue;
                    }

                    products.Add(productResponse.Payload);
                }

                //UpdateProduct
                foreach (var cartItem in cartItems)
                {
                    var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);

                    if (product != null)
                    {
                        var updatedStock = product.Stock - cartItem.Quantity;
                        if (updatedStock < 0)
                        {
                            Console.WriteLine($"Insufficient stock for product ID: {product.Id}. Available: {product.Stock}, Requested: {cartItem.Quantity}");
                            return BadRequest($"Insufficient stock for product: {product.Name}");
                        }

                        var productUpdateDTO = new ProductUpdateDTO
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price,
                            Stars = product.Stars,
                            Stock = updatedStock,
                            BrandId = product.BrandId,
                            CreatedAt = product.CreatedAt,
                            ShopId = product.ShopId,
                            HasDiscount = product.HasDiscount,
                            CategoryProductId = product.CategoryProductId,
                            CountryProductionId = product.CountryProductionId,
                        };

                        var updateResponse = await _productService.UpdateAsync(productUpdateDTO);
                        if (!updateResponse.Success)
                        {
                            Console.WriteLine($"Failed to update stock for product ID: {product.Id}. Error: {updateResponse.Message}");
                            return BadRequest($"Failed to update stock for product: {product.Name}");
                        }
                    }
                }

                // Order
                var order = new OrderCreateDTO
                {
                    AppUserId = appUserId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Pending",
                    TotalAmount = model.Amount,
                    OrderId = temporaryOrderId
                };

                var createdOrderResponse = await _orderService.AddAsync(order);
                if (!createdOrderResponse.Success)
                {
                    Console.WriteLine($"Failed to create order. Error: {createdOrderResponse.Message}");
                    return BadRequest("Failed to create order.");
                }

                var orderId = createdOrderResponse.Payload.Id;
                Console.WriteLine($"Order created successfully. Order ID: {orderId}");

                // OrderItem
                var orderItems = cartItems.Select(cartItem =>
                {
                    var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                    if (product == null)
                    {
                        Console.WriteLine($"Product not found for cart item. Product ID: {cartItem.ProductId}");
                        return null;
                    }

                    return new OrderItemCreateDTO
                    {
                        OrderId = orderId,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        Price = product.Price
                    };
                }).Where(oi => oi != null).ToList();

                foreach (var orderItem in orderItems)
                {
                    var orderItemResponse = await _orderItemService.AddAsync(orderItem);
                    if (!orderItemResponse.Success)
                    {
                        Console.WriteLine($"Failed to add order item. Order ID: {orderId}. Product ID: {orderItem.ProductId}. Error: {orderItemResponse.Message}");
                    }
                }

                // OrderStatusHistory
                var orderStatusHistory = new OrderStatusHistoryCreateDTO
                {
                    OrderId = orderId,
                    Status = "Pending",
                    ChangedAt = DateTime.UtcNow
                };

                var orderStatusHistoryResponse = await _orderStatusHistoryService.AddAsync(orderStatusHistory);
                if (!orderStatusHistoryResponse.Success)
                {
                    Console.WriteLine($"Failed to create order status history. Order ID: {orderId}. Error: {orderStatusHistoryResponse.Message}");
                }

                // Payment
                var payment = new PaymentCreateDTO
                {
                    OrderId = orderId,
                    PaymentMethod = "cash",
                    PaymentDate = DateTime.UtcNow,
                    Amount = model.Amount,
                    Status = "Pending"
                };

                var paymentResponse = await _paymentService.AddAsync(payment);
                if (!paymentResponse.Success)
                {
                    Console.WriteLine($"Failed to create payment record. Order ID: {orderId}. Error: {paymentResponse.Message}");
                    return BadRequest("Failed to create payment record.");
                }

                // Shipment
                var shipment = new ShipmentCreateDTO
                {
                    OrderId = orderId,
                    ShipmentDate = DateTime.UtcNow,
                    TrackingNumber = "None",
                    Carrier = "Nova Poshta",
                    Status = "Shipped",
                    Name = model.Name,
                    SurName = model.Surname,
                    PhoneNumber = model.Phone,
                    Email = model.Email,
                    Region = model.Area,
                    City = model.Settlement,
                    PickupPoint = model.DeliveryBranch
                };

                var shipmentResponse = await _shipmentService.AddAsync(shipment);
                if (!shipmentResponse.Success)
                {
                    Console.WriteLine($"Failed to create shipment record. Order ID: {orderId}. Error: {shipmentResponse.Message}");
                    return BadRequest("Failed to create shipment record.");
                }

                // Delete cart items
                foreach (var item in cartItems)
                {
                    try
                    {
                        var deleteResponse = await _cartItemService.Delete(item.Id);
                        if (!deleteResponse.Success)
                        {
                            Console.WriteLine($"Failed to delete cart item. CartItem ID: {item.Id}. Error: {deleteResponse.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting cart item with ID: {item.Id}. Exception: {ex.Message}");
                        return BadRequest($"Error deleting cart item with ID: {item.Id}");
                    }
                }

                Console.WriteLine($"Payment recorded successfully. Order ID: {orderId}");

                return Ok(new { message = "Payment created successfully", payload = $"http://techno.itstep.click/payment-result?order_id={temporaryOrderId}", success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while creating the payment", error = ex.Message, success = false });
            }
        }
    }



}
