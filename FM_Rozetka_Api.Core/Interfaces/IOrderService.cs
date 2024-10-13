using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<IEnumerable<OrderDTO>, object>> GetAllAsync();
        Task<ServiceResponse<OrderDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<OrderDTO, object>> GetByOrderIdAsync(string id);
        Task<ServiceResponse<Order, object>> AddAsync(OrderCreateDTO model);
        Task<ServiceResponse<Order, object>> UpdateAsync(OrderUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<SalesStatisticsDTO> GetSalesStatisticsForShop(int shopId);
        Task<IEnumerable<OrderDetailsDTO>> GetAllStatistics(int shopId);
        Task<ServiceResponse<decimal, object>> GetTotalSalesVolumeForLast7DaysAsync();
        Task<SalesStatisticsDTO> GetSalesStatistics();
        Task<IEnumerable<OrderDetailsDTO>> GetAllStatistic();
        Task<IEnumerable<OrderDetailsDTO>> GetAllStatisticByAppUserId(string appUserId);
    }
}

