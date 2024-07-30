using FM_Rozetka_Api.Core.DTOs.Shops;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeratorShopDTO = FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop.ModeratorShopDTO;

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
    }
}
