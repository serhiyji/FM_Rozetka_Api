using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderStatusHistoryService _orderStatusHistoryService;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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

            var orderItemsWithDate = orders.SelectMany(order => order.OrderItems.Select(item => new
            {
                OrderDate = order.OrderDate.Date, 
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                TotalPrice = item.Price * item.Quantity
            })).ToList();

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


    }

}
