using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Org.BouncyCastle.Crypto.Agreement.JPake;
using Rozetka_Api.Core.Entities;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace FM_Rozetka_Api.Core.Services
{
    internal class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        public BrandService(IRepository<Brand> brandRepo, IRepository<Product> productRepo, IMapper mapper)
        {
            this._brandRepo = brandRepo;
            this._productRepo = productRepo;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<Brand, object>> AddAsync(BrandCreateDTO brandCreateDTO)
        {
            var brandEntity = _mapper.Map<BrandCreateDTO, Brand>(brandCreateDTO);
            await _brandRepo.Insert(brandEntity);
            await _brandRepo.Save();
            return new ServiceResponse<Brand, object>(true, "", payload: brandEntity);
        }

        public async Task<PaginationResponse<List<BrandDTO>, object>> GetAllPagedAsync(int page = 1, int pageSize = 10)
        {
            return new PaginationResponse<List<BrandDTO>, object>(true, "",
                    payload: _mapper.Map<List<BrandDTO>>(await _brandRepo.GetListBySpec(new BrandSpecification.GetByPagination(page, pageSize))),
                    pageNumber: page, pageSize: pageSize, totalCount: await _brandRepo.GetCountRows()
                );
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            int productCount = await _productRepo.GetCountBySpec(new ProductSpecification.GetByBrandId(id));
            if (productCount > 0)
            {
                return new ServiceResponse<object, object>(false, "There are still products registered under this brand.");
            }
            await _brandRepo.Delete(id);
            await _brandRepo.Save();
            return new ServiceResponse<object, object>(true, "");
        }

        public async Task<ServiceResponse<BrandDTO, object>> GetByIdAsync(int id)
        {
            var brand = await _brandRepo.GetByID(id);
            if (brand == null)
            {
                return new ServiceResponse<BrandDTO, object>(false, "Brand not found.");
            }
            return new ServiceResponse<BrandDTO, object>(true, "", payload: _mapper.Map<BrandDTO>(brand));
        }

        public async Task<ServiceResponse<IEnumerable<BrandDTO>, object>> GetAllAsync()
        {
            var brands = await _brandRepo.GetAll();
            return new ServiceResponse<IEnumerable<BrandDTO>, object>(true, "", payload: _mapper.Map<IEnumerable<BrandDTO>>(brands));
        }

        public async Task<ServiceResponse<Brand, object>> UpdateAsync(BrandUpdateDTO brandUpdateDTO)
        {
            var brandEntity = _mapper.Map<BrandUpdateDTO, Brand>(brandUpdateDTO);
            await _brandRepo.Update(brandEntity);
            await _brandRepo.Save();
            return new ServiceResponse<Brand, object>(true, "", payload: brandEntity);
        }
    }
}
