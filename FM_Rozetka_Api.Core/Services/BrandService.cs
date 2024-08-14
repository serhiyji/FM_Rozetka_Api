using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using FM_Rozetka_Api.Core.Specifications.ProductSpecification;
using Org.BouncyCastle.Crypto.Agreement.JPake;
using Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Services
{
    internal class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        public BrandService(
                IRepository<Brand> brandRepo, 
                IRepository<Product> productRepo, 
                IMapper mapper
            )
        {
            this._brandRepo = brandRepo;
            this._productRepo = productRepo;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse> AddAsync(BrandCreateDTO brandCreateDTO)
        {
            await _brandRepo.Insert(_mapper.Map<BrandCreateDTO, Brand>(brandCreateDTO));
            await _brandRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            int count = await _productRepo.GetCountBySpec(new ProductSpecification.GetByBrandId(id));
            if (count > 0)
            {
                return new ServiceResponse(false, "there are still products registered under this brand");
            }
            await _brandRepo.Delete(id);
            await _productRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<PaginationResponse<List<BrandDTO>, object>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return new PaginationResponse<List<BrandDTO>, object>(true, "",
                    payload: _mapper.Map<List<BrandDTO>>(await _brandRepo.GetListBySpec(new BrandSpecification.GetByPagination(page, pageSize))),
                    pageNumber: page, pageSize: pageSize, totalCount: await _brandRepo.GetCountRows()
                );
        }

        public async Task<ServiceResponse<BrandDTO, object>> GetAsync(int id)
        {
            Brand brand = await _brandRepo.GetByID(id);
            if (brand == null)
            {
                return new ServiceResponse<BrandDTO, object>(false, "not found");
            }
            return new ServiceResponse<BrandDTO, object>(true, "", payload: _mapper.Map<Brand, BrandDTO>(brand));
        }

        public async Task<ServiceResponse> UpdateAsync(BrandUpdateDTO brandUpdateDTO)
        {
            await _brandRepo.Update(_mapper.Map<Brand>(brandUpdateDTO));
            await _productRepo.Save();
            return new ServiceResponse(true, "");
        }
    }
}
