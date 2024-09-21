using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IViewedProductService
    {
        Task<ServiceResponse> AddProduct(int productId, string appUSerId); 
        Task<ServiceResponse> GetByAppUserId(string appUserId, int count);
        Task<ServiceResponse> GetRecommendedProducts(string appUserId, int count);
    }
}
