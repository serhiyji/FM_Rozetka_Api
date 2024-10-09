using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<Product, object>> AddAsync(ProductCreateDTO model);
        Task<ServiceResponse<Product, object>> UpdateAsync(ProductUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<ProductDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<ProductDTO>, object>> GetAllAsync();
        Task<ServiceResponse<int, object>> GetCountByCategoryId(int categoryid);
        Task<PaginationResponse<List<ProductDTO>, object>> GetByShopIdAsync(int shopId, int pageNumber = 1, int pageSize = 10);
        Task<PaginationResponse<List<ProductDTO>, object>> GetPagedProductsAsync(int pageNumber, int pageSize);
        Task<PaginationResponse<List<ProductDTO>, object>> GetPagedFavoritesProductsAsync(List<int> FaforitesId,int pageNumber, int pageSize);
        Task<PaginationResponse<List<Product>, object>> FilterProductsBySpecifications(Dictionary<int, List<int>> filters, int page = 1, int pageSize = 10);
        Task<ServiceResponse> GetNewOnes(int count);
        Task<ServiceResponse> GetPopular(int count);
        Task<PaginationResponse<List<ProductDTO>, object>> GetSearchByName(string name, int pageNumber, int pageSize);
        Task<ServiceResponse<int, object>> GetProductCountAsync();
        Task<ServiceResponse<int, object>> GetNewProductsCountAsync();
    }
}
