using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IProductAnswerService
    {
        Task<ServiceResponse<ProductAnswerDTO, object>> CreateAsync(ProductAnswerCreateDTO model);
        Task<ServiceResponse<ProductAnswerDTO, object>> UpdateAsync(ProductAnswerUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<ProductAnswerDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<ProductAnswerDTO>, object>> GetAllAsync();
        Task<ServiceResponse<IEnumerable<ProductAnswerDTO>, object>> GetAllByQuestionId(int questionId);
    }
}
