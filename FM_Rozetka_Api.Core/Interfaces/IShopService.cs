using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<ShopDTO>> GetAllAsync();
        Task<ShopDTO> GetByIdAsync(int id);
        Task<ServiceResponse<Shop,object>> AddAsync(ShopCreateDTO model);
        Task UpdateAsync(ShopUpdateDTO model);
        Task<ShopDTO> GetByUserIdAsync(string id);
        Task DeleteAsync(int id);
    }
}
