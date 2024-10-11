using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    internal class ShopService : IShopService
    {
        private readonly IRepository<Shop> _shopRepository;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public ShopService(IRepository<Shop> shopRepository, IMapper mapper, ICompanyService companyService)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
            _companyService = companyService;
        }

        public async Task<ServiceResponse<Shop,object>> AddAsync(ShopCreateDTO model)
        {
            var shop = _mapper.Map<Shop>(model);
            await _shopRepository.Insert(shop);
            await _shopRepository.Save();
            return new ServiceResponse<Shop, object>(true, "Succes", payload: shop);
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

        public async Task<ShopDTO> GetByUserIdAsync(string id)
        {
            var shop = await _shopRepository.GetItemBySpec(new ShopSpecification.GetShopByUserId(id));
            var map = _mapper.Map<ShopDTO>(shop);
            return map;
        }



        public async Task<ShopDTO> GetByModeratorIdAsync(string id)
        {
            var shop = await _shopRepository.GetItemBySpec(new ShopSpecification.GetShopByModeratorId(id));
            return _mapper.Map<ShopDTO>(shop);
        }

        public async Task<ServiceResponse<object, object>> UpdateAsync(ShopUpdateDTO model)
        {
            try
            {
                var shop = _mapper.Map<Shop>(model);

                if (shop.Website == "null")
                {
                    shop.Website = "";
                }

                await _shopRepository.Update(shop);
                await _shopRepository.Save();

                model.Company.PhoneNumber = shop.PhoneNumber;
                await _companyService.UpdateApplicationAsync(model.Company);

                return new ServiceResponse<object, object>(true, "Shop updated successfully");
            }
            catch (Exception ex)
            { 
            
                Console.Error.WriteLine($"Error updating shop: {ex.Message}");

                return new ServiceResponse<object, object>(false, "Error updating shop");
            }
        }

        public async Task<ServiceResponse<int, object>> GetShopCountAsync()
        {
            try
            {
                var shops = await _shopRepository.GetAll();
                int shopCount = shops.Count();

                return new ServiceResponse<int, object>(true, "Shop count retrieved successfully", payload: shopCount);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving shop count: {ex.Message}");
                return new ServiceResponse<int, object>(false, "Error retrieving shop count");
            }
        }




    }
}
