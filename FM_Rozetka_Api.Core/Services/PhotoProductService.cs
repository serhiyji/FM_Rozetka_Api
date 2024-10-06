using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    internal class PhotoProductService: IPhotoProductService
    {
        private readonly IRepository<PhotoProduct> _photoProductRepository;
        private readonly IMapper _mapper;
        private const string imageFolder = "images";
        int[] sizes = { 320, 600, 1200 };
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

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var product = await _photoProductRepository.GetByID(id);
            if (product == null)
            {
                return new ServiceResponse<object, object>(false, "Product not found");
            }

            try
            {

                string root = Directory.GetCurrentDirectory();

                foreach (int size in sizes)
                {
                    string fullFileName = $"{size}_{product.NameImage}";
                    string imagePath = Path.Combine(root, imageFolder, fullFileName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при видалені файлу {ex.Message}");
                return new ServiceResponse<object, object>(false, "Photo not found");
            }

          
            await _photoProductRepository.Delete(id);
            await _photoProductRepository.Save();

            return new ServiceResponse<object, object>(true, "Photo successfully deleted");
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

        public async Task<IEnumerable<PhotoProductDTO>> GetByProductIdAsync(int productId)
        {
            var photos = await _photoProductRepository.GetListBySpec(new PhotoProductSpecification.GetByProductId(productId));
            return _mapper.Map<IEnumerable<PhotoProductDTO>>(photos);
        }

    }
}
