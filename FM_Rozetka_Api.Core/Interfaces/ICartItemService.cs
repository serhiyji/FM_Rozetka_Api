using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ICartItemService
    {
        Task<ServiceResponse> Create(CartItemCreateDTO cartItemCreateDTO);
        Task<ServiceResponse> Update(CartItemUpdateDTO cartItemUpdateDTO);
        Task<ServiceResponse> Delete(int Id);
        Task<ServiceResponse<CartItemDTO, object>> GetById(int Id);
        Task<ServiceResponse<List<CartItemDTO>, object>> GetAllByAppUserId(string userId);
        Task<ServiceResponse> SetCount(int Id, int newcount);
    }
}
