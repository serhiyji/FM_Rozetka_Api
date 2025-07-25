﻿using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FM_Rozetka_Api.Core.Specifications.OrderSpecification;

namespace FM_Rozetka_Api.Core.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderStatusHistoryService _orderStatusHistoryService;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper, IOrderStatusHistoryService orderStatusHistoryService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderStatusHistoryService = orderStatusHistoryService;
        }

        public async Task<ServiceResponse<Order, object>> AddAsync(OrderCreateDTO model)
        {
            var newOrder = _mapper.Map<Order>(model);
            try
            {
                await _orderRepository.Insert(newOrder);
                await _orderRepository.Save();

                var lastOrder = await _orderRepository.GetItemBySpec(new OrderSpecification.LastCreatedOrderSpec());

                if (lastOrder != null && lastOrder.OrderId == newOrder.OrderId)
                {
                    return new ServiceResponse<Order, object>(true, "Success", payload: lastOrder);
                }

                return new ServiceResponse<Order, object>(false, "Failed to retrieve the created order.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Order, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<Order, object>> UpdateAsync(OrderUpdateDTO model)
        {
            var order = await _orderRepository.GetByID(model.Id);
            if (order == null)
            {
                return new ServiceResponse<Order, object>(false, "Order not found");
            }

            try
            {
                var oldStatus = order.Status;

                _mapper.Map(model, order);

                await _orderRepository.Update(order);
                await _orderRepository.Save();

                if (oldStatus != order.Status)
                {
                    var orderStatusHistory = new OrderStatusHistoryCreateDTO
                    {
                        OrderId = order.Id,
                        Status = order.Status,
                        ChangedAt = DateTime.UtcNow
                    };
                    var historyResponse = await _orderStatusHistoryService.AddAsync(orderStatusHistory);
                   
                }
                return new ServiceResponse<Order, object>(true, "Success", payload: order);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Order, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByID(id);
            if (order == null)
            {
                return new ServiceResponse<object, object>(false, "Order not found");
            }

            try
            {
                await _orderRepository.Delete(order.Id);
                await _orderRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<OrderDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var order = await _orderRepository.GetByID(id);
                if (order == null)
                {
                    return new ServiceResponse<OrderDTO, object>(false, "Order not found");
                }

                return new ServiceResponse<OrderDTO, object>(true, "Success", payload: _mapper.Map<OrderDTO>(order));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<OrderDTO, object>> GetByOrderIdAsync(string orderId)
        {
            try
            {
                var order = await _orderRepository.GetItemBySpec(new OrderSpecification.GetByOidreId(orderId));
                if (order == null)
                {
                    return new ServiceResponse<OrderDTO, object>(false, "Order not found");
                }

                return new ServiceResponse<OrderDTO, object>(true, "Success", payload: _mapper.Map<OrderDTO>(order));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<OrderDTO>, object>> GetAllAsync()
        {
            try
            {
                var orders = await _orderRepository.GetAll();
                return new ServiceResponse<IEnumerable<OrderDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<OrderDTO>>(orders));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<OrderDTO>, object>(false, "Failed: " + ex.Message);
            }
        }


        public async Task<SalesStatisticsDTO> GetSalesStatisticsForShop(int shopId)
        {
            var now = DateTime.UtcNow;
            var lastWeek = now.AddDays(-7);
            var orders = await _orderRepository.GetListBySpec(new OrderSpecification.GetShopOrderStatistics(shopId));

            var orderItemsWithDate = orders
                .SelectMany(order => order.OrderItems
                    .Where(item => item.Product.ShopId == shopId) 
                    .Select(item => new
                    {
                        OrderDate = order.OrderDate.Date,
                        ProductId = item.ProductId,
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        TotalPrice = item.Price * item.Quantity
                    }))
                .ToList();

            var dailyStatistics = orderItemsWithDate
                .GroupBy(item => item.OrderDate)
                .Select(group => new DailySalesStatisticDTO
                {
                    Date = group.Key,
                    TotalQuantitySold = group.Sum(item => item.Quantity),
                    TotalRevenue = group.Sum(item => item.TotalPrice)
                })
                .OrderBy(stat => stat.Date)
                .ToList();

            var productStatistics = orderItemsWithDate
                .GroupBy(item => item.ProductId)
                .Select(group => new SalesStatisticDTO
                {
                    ProductId = group.Key,
                    ProductName = group.First().ProductName,
                    QuantitySold = group.Sum(item => item.Quantity),
                    TotalRevenue = group.Sum(item => item.TotalPrice)
                })
                .ToList();

            return new SalesStatisticsDTO
            {
                DailyStatistics = dailyStatistics,
                ProductStatistics = productStatistics
            };
        }

        public async Task<SalesStatisticsDTO> GetSalesStatistics()
        {
            var now = DateTime.UtcNow;
            var lastWeek = now.AddDays(-7);

            var orders = await _orderRepository.GetListBySpec(new OrderSpecification.GetAllOrdersStatistics());

            var lastTenOrders = orders
       .OrderByDescending(order => order.OrderDate)
       .Take(10)
       .ToList();

            var orderItemsWithDate = orders
                .SelectMany(order => order.OrderItems
                    .Select(item => new
                    {
                        OrderDate = order.OrderDate.Date,
                        ProductId = item.ProductId,
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        TotalPrice = item.Price * item.Quantity
                    }))
                .ToList();

            var dailyStatistics = orderItemsWithDate
                .GroupBy(item => item.OrderDate)
                .Select(group => new DailySalesStatisticDTO
                {
                    Date = group.Key,
                    TotalQuantitySold = group.Sum(item => item.Quantity),
                    TotalRevenue = group.Sum(item => item.TotalPrice)
                })
                .OrderBy(stat => stat.Date)
                .ToList();

            var productStatistics = orderItemsWithDate
                .GroupBy(item => item.ProductId)
                .Select(group => new SalesStatisticDTO
                {
                    ProductId = group.Key,
                    ProductName = group.First().ProductName,
                    QuantitySold = group.Sum(item => item.Quantity),
                    TotalRevenue = group.Sum(item => item.TotalPrice)
                })
                .ToList();

            return new SalesStatisticsDTO
            {
                DailyStatistics = dailyStatistics,
                ProductStatistics = productStatistics
            };
        }


        public async Task<IEnumerable<OrderDetailsDTO>> GetAllStatistics(int shopId)
        {
            var orders = await _orderRepository.GetListBySpec(new OrderSpecification.GetOrderByShopId(shopId));

            var orderDetailsList = new List<OrderDetailsDTO>();
            foreach (var order in orders)
            {
                var filteredProducts = order.OrderItems
                    .Where(orderItem => orderItem.Product.ShopId == shopId)
                    .Select(orderItem => new ProductDetailsDTO
                    {
                        ProductId = orderItem.Product.Id,
                        ProductName = orderItem.Product.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Product.Price
                    }).ToList();

                if (!filteredProducts.Any())
                {
                    continue;
                }
                var totalAmount = filteredProducts.Sum(item => item.Quantity * item.Price);
                if (totalAmount == 0)
                {
                    await DeleteAsync(order.Id);
                    continue;
                }

                var orderDetails = new OrderDetailsDTO
                {
                    OrderId = order.Id,
                    OrderNumber = order.OrderId,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalAmount = totalAmount,
                    Products = filteredProducts
                };

                orderDetailsList.Add(orderDetails);
            }

            return orderDetailsList;
        }

        public async Task<IEnumerable<OrderDetailsDTO>> GetAllStatistic()
        {
            var orders = await _orderRepository.GetListBySpec(new GetAllOrders());

            var orderDetailsList = new List<OrderDetailsDTO>();
            foreach (var order in orders)
            {
                var allProducts = order.OrderItems
                    .Select(orderItem => new ProductDetailsDTO
                    {
                        ProductId = orderItem.Product.Id,
                        ProductName = orderItem.Product.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Product.Price
                    }).ToList();

                var totalAmount = allProducts.Sum(item => item.Quantity * item.Price);

                if (totalAmount == 0)
                {
                    await DeleteAsync(order.Id);
                    continue;
                }

                var orderDetails = new OrderDetailsDTO
                {
                    OrderId = order.Id,
                    OrderNumber = order.OrderId,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalAmount = totalAmount,
                    Products = allProducts
                };

                orderDetailsList.Add(orderDetails);
            }

            return orderDetailsList;
        }

        public async Task<IEnumerable<OrderDetailsDTO>> GetAllStatisticByAppUserId(string appUserId)
        {
            var orders = await _orderRepository.GetListBySpec(new GetAllOrdersByUserId(appUserId));

            var orderDetailsList = new List<OrderDetailsDTO>();
            foreach (var order in orders)
            {
                var allProducts = order.OrderItems
                    .Select(orderItem => new ProductDetailsDTO
                    {
                        ProductId = orderItem.Product.Id,
                        ProductName = orderItem.Product.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Product.Price
                    }).ToList();

                var totalAmount = allProducts.Sum(item => item.Quantity * item.Price);

                if (totalAmount == 0)
                {
                    await DeleteAsync(order.Id);
                    continue;
                }

                var orderDetails = new OrderDetailsDTO
                {
                    OrderId = order.Id,
                    OrderNumber = order.OrderId,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalAmount = totalAmount,
                    Products = allProducts
                };

                orderDetailsList.Add(orderDetails);
            }

            return orderDetailsList;
        }

        public async Task<ServiceResponse<decimal, object>> GetTotalSalesVolumeForLast7DaysAsync()
        {
            try
            {
                var orders = await _orderRepository.GetListBySpec(new OrderSpecification.GetOrdersForLast7Days());

                var totalSalesVolume = orders.Sum(order => order.OrderItems.Sum(item => item.Quantity * item.Product.Price));

                return new ServiceResponse<decimal, object>(true, "Total sales volume retrieved successfully", payload: totalSalesVolume);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving sales volume: {ex.Message}");
                return new ServiceResponse<decimal, object>(false, "Error retrieving sales volume");
            }
        }


    }

}
