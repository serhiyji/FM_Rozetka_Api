using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly string _encryptionKey;

        public PaymentController(IPaymentService paymentService, IConfiguration configuration, LiqPayService liqPayService,
            IOrderService orderService, IOrderItemService orderItemService, ICartItemService cartItemService, IProductService productService,
            IOrderStatusHistoryService orderStatusHistoryService)
        {
            _paymentService = paymentService;
            _liqPayService = liqPayService;
            _encryptionKey = configuration["Encryption:Key"];
            _orderService = orderService;
            _orderItemService = orderItemService;
            _cartItemService = cartItemService;
            _productService = productService;
            _orderStatusHistoryService = orderStatusHistoryService;
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
            var response = await _liqPayService.CreatePaymentLink(model.Amount, model.Currency, model.Description, model.CartItemIds);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("callback")]
        public async Task<IActionResult> PaymentCallback([FromForm] string data, [FromForm] string signature)
        {
            try
            {
                if (!_liqPayService.VerifySignature(data, signature))
                {
                    Console.WriteLine("Invalid signature");
                    return BadRequest("Invalid signature");
                }

                var decodedData = Encoding.UTF8.GetString(Convert.FromBase64String(data));
                dynamic paymentInfo = Newtonsoft.Json.Linq.JObject.Parse(decodedData);
                Console.WriteLine($"Payment info: {decodedData}");

                string descriptionText = paymentInfo.description;
                Console.WriteLine($"Description: {descriptionText}");

                string decryptedDescription = null; 

                var regex = new System.Text.RegularExpressions.Regex(@"\(([^)]+)\)");
                var match = regex.Match(descriptionText);
                if (match.Success)
                {
                    string encryptedDescription = match.Groups[1].Value.Trim();
                    Console.WriteLine($"Extracted encrypted description: {encryptedDescription}");

                    try
                    {
                        decryptedDescription = Utility.Decrypt(encryptedDescription, _encryptionKey);
                        Console.WriteLine($"Decrypted description: {decryptedDescription}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Decryption failed: {ex.Message}");
                        return BadRequest("Decryption failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to extract encrypted description.");
                    return BadRequest("Failed to extract encrypted description.");
                }
             
                var orderIds = decryptedDescription.Split('|').Select(id => int.Parse(id)).ToArray();
                Console.WriteLine($"Order IDs: {string.Join(", ", orderIds)}");

                if (paymentInfo.status == "success" || paymentInfo.status == "sandbox")
                {
                    Console.WriteLine($"Payment status: {paymentInfo.status}. Order ID: {paymentInfo.order_id}");

                    try
                    {
                        var response = await _cartItemService.GetByIds(orderIds);
                        if (!response.Success)
                        {
                            Console.WriteLine($"Failed to get cart items. Order ID: {paymentInfo.order_id}. Error: {response.Message}");
                            return BadRequest("Failed to get cart items.");
                        }

                        var cartItems = response.Payload;
                        var appUserId = cartItems.First().AppUserId;

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
                            PaymentMethod = paymentInfo.payment_method,
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


    }
}
