using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ICategoryProductService
    {
        Task<IEnumerable<CategoryProductDTO>> GetAllAsync();
        Task<CategoryProductDTO> GetByIdAsync(int id);
        Task<ServiceResponse<CategoryProduct, object>> AddAsync(CategoryProductCreateDTO application);
        Task UpdateAsync(CategoryProductUpdateDTO application);
        Task DeletenAsync(int id);


    }
}
