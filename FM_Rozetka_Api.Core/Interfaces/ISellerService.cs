using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<SellerApplicationDTO>> GetAllActivityApplicationsAsync();
        Task<IEnumerable<SellerApplicationDTO>> GetAllApplicationsAsync();
        Task<SellerApplicationDTO> GetApplicationByIdAsync(int id);
        Task<SellerApplication> AddApplicationAsync(CreateSellerApplicationDTO application);
        Task UpdateApplicationStatusAsync(SellerApplicationDTO application);
        Task UpdateApplicationAsync(UpdateSellerApplicationDTO application);
        Task DeleteApplicationAsync(int id);
        Task<ServiceResponse<int, object>> GetAppCountAsync();
    }
}
