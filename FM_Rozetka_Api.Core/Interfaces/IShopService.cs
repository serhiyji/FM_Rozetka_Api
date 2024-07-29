using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
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
        Task<Shop> AddAsync(ShopCreateDTO model);
        Task UpdateAsync(ShopUpdateDTO model);
        Task DeleteAsync(int id);
    }
}
