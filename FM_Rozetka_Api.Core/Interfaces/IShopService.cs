﻿using FM_Rozetka_Api.Core.DTOs.Discount;
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
        Task<ServiceResponse> DeleteAsync(int Id);
        Task<ServiceResponse<int, object>> GetShopCountAsync();
        Task<PaginationResponse<List<ShopDTO>, object>> GetPagedShopsAsync(string? name = null, int page = 1, int pageSize = 10);
    }
}
