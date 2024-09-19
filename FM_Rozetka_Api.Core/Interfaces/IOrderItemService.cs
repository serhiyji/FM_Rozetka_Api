using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IOrderItemService
    {
        Task<ServiceResponse<IEnumerable<OrderItemDTO>, object>> GetAllAsync();
        Task<ServiceResponse<IEnumerable<OrderItemDTO>, object>> GetAllOrderId(int id);
        Task<ServiceResponse<OrderItemDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<OrderItem, object>> AddAsync(OrderItemCreateDTO model);
        Task<ServiceResponse<OrderItem, object>> UpdateAsync(OrderItemUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
    }


}
