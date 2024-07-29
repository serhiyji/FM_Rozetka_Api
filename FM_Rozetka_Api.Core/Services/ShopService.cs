using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IRepository<Shop> _shopRepository;
        private readonly IMapper _mapper;
    
        public ShopService(IRepository<Shop> shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<Shop> AddAsync(ShopCreateDTO model)
        {
            var shop = _mapper.Map<Shop>(model);
            await _shopRepository.Insert(shop);
            await _shopRepository.Save();
            return shop;
        }
      
        public async Task DeleteAsync(int id)
        {
            await _shopRepository.Delete(id);
            await _shopRepository.Save();
        }

        public async Task<IEnumerable<ShopDTO>> GetAllAsync()
        {
            var shop = await _shopRepository.GetAll();
            return _mapper.Map<IEnumerable<ShopDTO>>(shop);
        }

        public async Task<ShopDTO> GetByIdAsync(int id)
        {
            var shop = await _shopRepository.GetByID(id);
            return _mapper.Map<ShopDTO>(shop);
        }

        public async Task UpdateAsync(ShopUpdateDTO model)
        {
            var shop = _mapper.Map<Shop>(model);
            await _shopRepository.Update(shop);
            await _shopRepository.Save();
        }
    }
}
