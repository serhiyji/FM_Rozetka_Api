using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<ServiceResponse<IEnumerable<PaymentDTO>, object>> GetAllAsync();
        Task<ServiceResponse<PaymentDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<Payment, object>> AddAsync(PaymentCreateDTO model);
        Task<ServiceResponse<Payment, object>> UpdateAsync(PaymentUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
    }
}
