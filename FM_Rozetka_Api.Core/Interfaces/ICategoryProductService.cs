using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ICategoryProductService
    {
        Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetAllAsync();
        Task<ServiceResponse<CategoryProductDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<CategoryProduct, object>> AddAsync(CategoryProductCreateDTO application);
        Task<ServiceResponse<object, object>> UpdateAsync(CategoryProductUpdateDTO application);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetAllSortedAsync();

        Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetFirstLevelCategoriesAsync();
        Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetSubCategoriesByTopIdAsync(int topId);

    }
}
