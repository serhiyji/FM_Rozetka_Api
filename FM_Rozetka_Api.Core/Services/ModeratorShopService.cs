using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeratorShopDTO = FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop.ModeratorShopDTO;

namespace FM_Rozetka_Api.Core.Services
{
    public class ModeratorShopService : IModeratorShopService
    {
        private readonly IRepository<ModeratorShop> _moderatorShopRepository;
        private readonly IMapper _mapper;

        private readonly IShopService _shopService;
        private readonly IUserService _userService;


      
        public ModeratorShopService(IRepository<ModeratorShop> moderatorShopRepository, IUserService userService, IMapper mapper, IShopService shopService)
        {
            _moderatorShopRepository = moderatorShopRepository;
            _mapper = mapper;
            _shopService = shopService;
            _userService = userService;
        }

        public async Task<ServiceResponse<ModeratorShop, object>> AddAsync(ModeratorShopCreateDTO model)
        {
            var shop = await _shopService.GetByIdAsync(model.ShopId);
            if (shop == null)
            {
                return new ServiceResponse<ModeratorShop, object>(false, "Shop not found");
            }

            var user = await _userService.GetUserByIdAsync(model.AppUserId);
            if (user == null)
            {
                return new ServiceResponse<ModeratorShop, object>(false, "User not found");
            }
            var moderatorShop = _mapper.Map<ModeratorShop>(model);
            await _moderatorShopRepository.Insert(moderatorShop);
            await _moderatorShopRepository.Save();
            return new ServiceResponse<ModeratorShop, object>(true, "Succes", payload: moderatorShop);
        }

        public async Task DeleteAsync(int id)
        {
            await _moderatorShopRepository.Delete(id);
            await _moderatorShopRepository.Save();
        }

        public async Task<IEnumerable<ModeratorShopDTO>> GetAllAsync()
        {
            var moderatorShop = await _moderatorShopRepository.GetAll();
            return _mapper.Map<IEnumerable<ModeratorShopDTO>>(moderatorShop);
        }

        public async Task<ModeratorShopDTO> GetByIdAsync(int id)
        {
            var moderatorShop = await _moderatorShopRepository.GetByID(id);
            return _mapper.Map<ModeratorShopDTO>(moderatorShop);
        }

        public async Task UpdateAsync(ModeratorShopUpdateDTO model)
        {
            var moderatorShop = _mapper.Map<ModeratorShop>(model);
            await _moderatorShopRepository.Update(moderatorShop);
            await _moderatorShopRepository.Save();
        }

       

     
    }
}
