using FM_Rozetka_Api.Core.DTOs.Shops;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IModeratorShopService
    {
        Task<IEnumerable<ModeratorShopDTO>> GetAllAsync();
        Task<ModeratorShopDTO> GetByIdAsync(int id);
        Task<ServiceResponse<ModeratorShop, object>> AddAsync(ModeratorShopCreateDTO model);
        Task UpdateAsync(ModeratorShopUpdateDTO model);
        Task DeleteAsync(int id);

        Task<ServiceResponse> AddModeratorShopAsync(CreateModeratorUserDTO model);
        Task<ServiceResponse<IEnumerable<UserModeratorShopDTO>, object>> GetUsersByShopId(int shopid);
        Task<ServiceResponse> ConfirmModeratorRoleAsync(ConfirmModeratorRoleDTO model);
    }
}
