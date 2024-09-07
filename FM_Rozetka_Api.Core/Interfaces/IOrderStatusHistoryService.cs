using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IOrderStatusHistoryService
    {
        Task<ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>> GetAllAsync();
        Task<ServiceResponse<OrderStatusHistoryDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<OrderStatusHistory, object>> AddAsync(OrderStatusHistoryCreateDTO model);
        Task<ServiceResponse<OrderStatusHistory, object>> UpdateAsync(OrderStatusHistoryUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
    }
}
