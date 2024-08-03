using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CountryProduction;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    public class PhotoProductService: IPhotoProductService
    {
        private readonly IRepository<PhotoProduct> _photoProductRepository;
        private readonly IMapper _mapper;

        public PhotoProductService(IRepository<PhotoProduct> photoProductRepository, IMapper mapper)
        {
            _photoProductRepository = photoProductRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PhotoProduct, object>> AddAsync(PhotoProductCreateDTO model)
        {
            var photo = _mapper.Map<PhotoProduct>(model);
            await _photoProductRepository.Insert(photo);
            await _photoProductRepository.Save();
            return new ServiceResponse<PhotoProduct, object>(true, "Succes", payload: photo);
        }

        public async Task DeleteAsync(int id)
        {
            await _photoProductRepository.Delete(id);
            await _photoProductRepository.Save();
        }

        public async Task<IEnumerable<PhotoProductDTO>> GetAllAsync()
        {
            var photo = await _photoProductRepository.GetAll();
            return _mapper.Map<IEnumerable<PhotoProductDTO>>(photo);
        }

        public async Task<PhotoProductDTO> GetByIdAsync(int id)
        {
            var photo = await _photoProductRepository.GetByID(id);
            return _mapper.Map<PhotoProductDTO>(photo);
        }

        public async Task<ServiceResponse<PhotoProduct, object>> UpdateAsync(PhotoProductUpdateDTO model)
        {
            var photo = await _photoProductRepository.GetByID(model.Id);
            if (photo == null)
            {
                return new ServiceResponse<PhotoProduct, object>(false, "PhotoProduct not found");
            }

            _mapper.Map(model, photo);
            await _photoProductRepository.Update(photo);
            await _photoProductRepository.Save();

            return new ServiceResponse<PhotoProduct, object>(true, "Success", payload: photo);
        }
    }
}
