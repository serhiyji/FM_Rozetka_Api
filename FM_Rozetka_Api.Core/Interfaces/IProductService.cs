using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<Product, object>> AddAsync(ProductCreateDTO model);
        Task<ServiceResponse<Product, object>> UpdateAsync(ProductUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<ProductDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<ProductDTO>, object>> GetAllAsync();
    }
}
