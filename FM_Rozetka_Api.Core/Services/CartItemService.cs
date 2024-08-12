using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepository<CartItem> _cartItemRepo;
        private readonly IMapper _mapper;
        public CartItemService(
                IRepository<CartItem> cartItemRepo, 
                IMapper mapper
            )
        {
            this._cartItemRepo = cartItemRepo;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse> Create(CartItemCreateDTO cartItemCreateDTO)
        {
            await _cartItemRepo.Insert(_mapper.Map<CartItemCreateDTO, CartItem>(cartItemCreateDTO));
            await _cartItemRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse> Delete(int Id)
        {
            await _cartItemRepo.Delete(Id);
            await _cartItemRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse<List<CartItemDTO>, object>> GetAllByAppUserId(string userId)
        {
            List<CartItemDTO> res = (List<CartItemDTO>)await _cartItemRepo.GetListBySpec(new CartItemSpecification.GetByAppUserId(userId));
            return new ServiceResponse<List<CartItemDTO>, object>(true, "", payload: _mapper.Map<List<CartItemDTO>>(res));
        }

        public async Task<ServiceResponse<CartItemDTO, object>> GetById(int Id)
        {
            CartItem cartItem = await _cartItemRepo.GetByID(Id);
            if (cartItem == null)
            {
                return new ServiceResponse<CartItemDTO, object>(false, "Not found");
            }
            return new ServiceResponse<CartItemDTO, object>(true, "", payload: _mapper.Map<CartItem, CartItemDTO>(cartItem));
        }

        public async Task<ServiceResponse> Update(CartItemUpdateDTO cartItemUpdateDTO)
        {
            await _cartItemRepo.Insert(_mapper.Map<CartItemUpdateDTO, CartItem>(cartItemUpdateDTO));
            await _cartItemRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse> SetCount(int Id, int newcount)
        {
            CartItem cartItem = await _cartItemRepo.GetByID(Id);
            if (cartItem == null)
            {
                return new ServiceResponse(false, "Not found");
            }
            cartItem.Quantity = newcount;
            await _cartItemRepo.Update(cartItem);
            await _cartItemRepo.Save();
            return new ServiceResponse(true, "");
        }
    }
}
