using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Telegram.Bot.Types;

namespace FM_Rozetka_Api.Core.Services
{
    internal class CartItemService : ICartItemService
    {
        private readonly IRepository<CartItem> _cartItemRepo;
        private readonly IMapper _mapper;
        public CartItemService(IRepository<CartItem> cartItemRepo, IMapper mapper)
        {
            this._cartItemRepo = cartItemRepo;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<CartItem, object>> Create(CartItemCreateDTO cartItemCreateDTO)
        {
            try
            {
                var newCartItem = _mapper.Map<CartItem>(cartItemCreateDTO);
                await _cartItemRepo.Insert(newCartItem);
                await _cartItemRepo.Save();
                return new ServiceResponse<CartItem, object>(true, "Success", payload: newCartItem);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<CartItem, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse> Delete(int Id)
        {
            var cartItem = await _cartItemRepo.GetByID(Id);
            if (cartItem == null)
            {
                return new ServiceResponse(false, "cartItem not found");
            }
            try
            {
                await _cartItemRepo.Delete(Id);
                await _cartItemRepo.Save();
                return new ServiceResponse(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, "Failed: " + ex.Message);
            }
        }

      

        public async Task<ServiceResponse<List<CartItemDTO>, object>> GetAllByAppUserId(string userId)
        {
            try
            {
                var cartItems = await _cartItemRepo.GetListBySpec(new CartItemSpecification.GetByAppUserId(userId));

                if (cartItems == null || !cartItems.Any())
                {
                    return new ServiceResponse<List<CartItemDTO>, object>(false, "Cart items not found");
                }

                return new ServiceResponse<List<CartItemDTO>, object>(true, "Success", payload: _mapper.Map<List<CartItemDTO>>(cartItems) );
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<CartItemDTO>, object>(false, "Failed: " + ex.Message);
            }
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

        public async Task<ServiceResponse<CartItem, object>> Update(CartItemUpdateDTO cartItemUpdateDTO)
        {
            var existingCartItem = await _cartItemRepo.GetByID(cartItemUpdateDTO.Id);
            if (existingCartItem == null)
            {
                return new ServiceResponse<CartItem, object>(false, "Cart item not found");
            }

            try
            {
                _mapper.Map(cartItemUpdateDTO, existingCartItem);
                await _cartItemRepo.Update(existingCartItem);
                await _cartItemRepo.Save();

                return new ServiceResponse<CartItem, object>(true, "Success", payload: existingCartItem);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<CartItem, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<CartItemDTO, object>> SetCount(int id, int newCount)
        {
            if (newCount < 1)
            {
                return new ServiceResponse<CartItemDTO, object>(false, "Quantity must be at least 1");
            }

            CartItem cartItem = await _cartItemRepo.GetByID(id);
            if (cartItem == null)
            {
                return new ServiceResponse<CartItemDTO, object>(false, "Cart item not found");
            }

            cartItem.Quantity = newCount;
            await _cartItemRepo.Update(cartItem);
            await _cartItemRepo.Save();
            return new ServiceResponse<CartItemDTO, object>(true, "Quantity updated successfully", payload: _mapper.Map<CartItem, CartItemDTO>(cartItem));
        }

        public async Task<ServiceResponse<List<CartItemDTO>, object>> GetByIds(int[] Ids)
        {
            try
            {
                var cartItems = await _cartItemRepo.GetListBySpec(new CartItemSpecification.GetByIds(Ids));

                if (cartItems == null || !cartItems.Any())
                {
                    return new ServiceResponse<List<CartItemDTO>, object>(false, "Cart items not found");
                }

                return new ServiceResponse<List<CartItemDTO>, object>(true, "Success", payload: _mapper.Map<List<CartItemDTO>>(cartItems));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<CartItemDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }
}
