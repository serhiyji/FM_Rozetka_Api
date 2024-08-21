using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications.ProductSpecification;

namespace FM_Rozetka_Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IFilesService _filesService;
        private readonly IPhotoProductService _photoProductService;

        public ProductService(IMapper mapper, IRepository<Product> productRepository, IFilesService filesService, IPhotoProductService photoProductService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _filesService = filesService;
            _photoProductService = photoProductService;
        }

        public async Task<ServiceResponse<Product, object>> AddAsync(ProductCreateDTO model)
        {
            var newProduct = _mapper.Map<Product>(model);
            try
            {
                if (model.MainImageFile != null)
                {
                    newProduct.ImageURL = await _filesService.SaveImage(model.MainImageFile);
                }
                else
                {
                    newProduct.ImageURL = "noimage.webp";
                }

                await _productRepository.Insert(newProduct);
                await _productRepository.Save();

                if (model.AdditionalImageFiles != null)
                {
                    foreach (var imageFile in model.AdditionalImageFiles)
                    {
                        var photo = new PhotoProductCreateDTO
                        {
                            ProductId = newProduct.Id,
                            NameImage = await _filesService.SaveImage(imageFile)
                        };
                        await _photoProductService.AddAsync(photo);
                    }
                }

                return new ServiceResponse<Product, object>(true, "Success", payload: newProduct);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Product, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<Product, object>> UpdateAsync(ProductUpdateDTO model)
        {
            var product = await _productRepository.GetByID(model.Id);
            if (product == null)
            {
                return new ServiceResponse<Product, object>(false, "Product not found");
            }

            try
            {
                _mapper.Map(model, product);

                if (model.MainImageFile != null)
                {
                    if (product.ImageURL != "noimage.webp")
                    {
                        await _filesService.DeleteImage(product.ImageURL);
                    }
                    product.ImageURL = await _filesService.SaveImage(model.MainImageFile);
                }

                await _productRepository.Update(product);
                await _productRepository.Save();

                if (model.AdditionalImageFiles != null)
                {
                    var existingPhotos = await _photoProductService.GetByProductIdAsync(product.Id);
                    foreach (var photo in existingPhotos)
                    {
                        await _filesService.DeleteImage(photo.NameImage);
                        await _photoProductService.DeleteAsync(photo.Id);
                    }

                    foreach (var imageFile in model.AdditionalImageFiles)
                    {
                        var photo = new PhotoProductCreateDTO
                        {
                            ProductId = product.Id,
                            NameImage = await _filesService.SaveImage(imageFile)
                        };
                        await _photoProductService.AddAsync(photo);
                    }
                }

                return new ServiceResponse<Product, object>(true, "Success", payload: product);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Product, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByID(id);
            if (product == null)
            {
                return new ServiceResponse<object, object>(false, "Product not found");
            }

            try
            {
                if (product.ImageURL != "noimage.webp")
                {
                    await _filesService.DeleteImage(product.ImageURL);
                }

                var photos = await _photoProductService.GetByProductIdAsync(product.Id);
                foreach (var photo in photos)
                {
                    await _filesService.DeleteImage(photo.NameImage);
                    await _photoProductService.DeleteAsync(photo.Id);
                }

                await _productRepository.Delete(product.Id);
                await _productRepository.Save();

                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductDTO>, object>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAll();
                return new ServiceResponse<IEnumerable<ProductDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<ProductDTO>>(products));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByID(id);
                if (product == null)
                {
                    return new ServiceResponse<ProductDTO, object>(false, "Product not found");
                }

                return new ServiceResponse<ProductDTO, object>(true, "Success", payload: _mapper.Map<ProductDTO>(product));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductDTO>, object>> GetByShopIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetListBySpec(new ProductSpecification.GetByShopID(id));
                if (product == null)
                {
                    return new ServiceResponse<IEnumerable<ProductDTO>, object>(false, "Product not found");
                }

                return new ServiceResponse<IEnumerable<ProductDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<ProductDTO>>(product));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<int, object>> GetCountByCategoryId(int categoryid)
        {
            try
            {
                var product = await _productRepository.GetCountBySpec(new ProductSpecification.GetByCategoryID(categoryid));
                if (product == null)
                {
                    return new ServiceResponse<int, object>(false, "Product not found");
                }

                return new ServiceResponse<int, object>(true, "Success", payload: product);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int, object>(false, "Failed: " + ex.Message);
            }
        }
    }
}
