using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IProductQuestionService
    {
        Task<ServiceResponse<ProductQuestion, object>> AddAsync(ProductQuestionCreateDTO model);
        Task<ServiceResponse<ProductQuestion, object>> UpdateAsync(ProductQuestionUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<ProductQuestionDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<ProductQuestionDTO>, object>> GetAllAsync();
        Task<ServiceResponse<IEnumerable<ProductQuestionDTO>, object>> GetAllByProductIdAsync(int productid);
    }

}
