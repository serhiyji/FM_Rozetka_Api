using FM_Rozetka_Api.Core.DTOs.Discount;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IDiscountService
    {
        Task<ServiceResponse<Discount, object>> AddAsync(DiscountCreateDTO model);
        Task<ServiceResponse<Discount, object>> UpdateAsync(DiscountUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<DiscountDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<DiscountDTO>, object>> GetAllAsync();
        Task<ServiceResponse<object, object>> DeleteExpiredDiscountsAsync();
    }
}
