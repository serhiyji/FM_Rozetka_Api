using FM_Rozetka_Api.Core.DTOs.Discount;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<ShopDTO>> GetAllAsync();
        Task<ShopDTO> GetByIdAsync(int id);
        Task<ServiceResponse<Shop,object>> AddAsync(ShopCreateDTO model);
        Task<ServiceResponse<object, object>> UpdateAsync(ShopUpdateDTO model);
        Task<ShopDTO> GetByUserIdAsync(string id);
        Task<ShopDTO> GetByModeratorIdAsync(string id);
        Task DeleteAsync(int id);
        Task<ServiceResponse<int, object>> GetShopCountAsync();
    }
}
