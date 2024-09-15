using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ICartItemService
    {
        Task<ServiceResponse<CartItem, object>> Create(CartItemCreateDTO cartItemCreateDTO);
        Task<ServiceResponse<CartItem, object>> Update(CartItemUpdateDTO cartItemUpdateDTO);
        Task<ServiceResponse> Delete(int Id);
        Task<ServiceResponse<CartItemDTO, object>> GetById(int Id);
        Task<ServiceResponse<List<CartItemDTO>, object>> GetByIds(int[] Ids);
        Task<ServiceResponse<List<CartItemDTO>, object>> GetAllByAppUserId(string userId);
        Task<ServiceResponse<CartItemDTO, object>> SetCount(int Id, int newcount); 
    }
}
