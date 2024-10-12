using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FM_Rozetka_Api.Core.Services
{
    internal class ProductService : IProductService
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

        //public async Task<ServiceResponse<IEnumerable<ProductDTO>, object>> GetByShopIdAsync(int id)
        //{
        //    try
        //    {
        //        var product = await _productRepository.GetListBySpec(new ProductSpecification.GetByShopID(id));
        //        if (product == null)
        //        {
        //            return new ServiceResponse<IEnumerable<ProductDTO>, object>(false, "Product not found");
        //        }

        //        return new ServiceResponse<IEnumerable<ProductDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<ProductDTO>>(product));
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ServiceResponse<IEnumerable<ProductDTO>, object>(false, "Failed: " + ex.Message);
        //    }
        //}

        public async Task<PaginationResponse<List<ProductDTO>, object>> GetByShopIdAsync(int shopId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var specification = new ProductSpecification.GetByShopIdWithPagination(shopId, pageNumber, pageSize);

                var products = await _productRepository.GetListBySpec(specification);

                var totalCount = await _productRepository.GetCountBySpec(new ProductSpecification.GetByShopIdWithPagination(shopId, 1, int.MaxValue));

                var productDTOs = _mapper.Map<List<ProductDTO>>(products);

                return new PaginationResponse<List<ProductDTO>, object>(true, "Success", payload: productDTOs, pageNumber: pageNumber, pageSize: pageSize, totalCount: totalCount);
            }
            catch (Exception ex)
            {
                return new PaginationResponse<List<ProductDTO>, object>(false, "Failed: " + ex.Message);
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

        public async Task<PaginationResponse<List<ProductDTO>, object>> GetPagedProductsAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                return new PaginationResponse<List<ProductDTO>, object>(true, "",
                    payload: _mapper.Map<List<ProductDTO>>(await _productRepository.GetListBySpec(new ProductSpecification.GetByPagination(page, pageSize))),
                    pageNumber: page, pageSize: pageSize, totalCount: await _productRepository.GetCountRows()
                );
            }
            catch (Exception ex)
            {
                return new PaginationResponse<List<ProductDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<PaginationResponse<List<Product>, object>> FilterProductsBySpecifications(
                Dictionary<int, List<int>> filters,
                int page = 1,
                int pageSize = 10
            )
        {
            var query = _productRepository.dbSet.AsQueryable();

            foreach (var filter in filters)
            {
                int specificationId = filter.Key;
                List<int> possibleSpecificationItemIds = filter.Value;

                query = query.Where(p => p.Specifications
                    .Any(s => s.PossibleSpecificationItemId == specificationId &&
                              possibleSpecificationItemIds.Contains(s.PossibleSpecificationItemId)));
            }

            List<Product> products = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginationResponse<List<Product>, object>(true, "", payload: products,
                pageNumber: page, pageSize: pageSize, totalCount: query.Count());
        }

        public async Task<ServiceResponse> GetNewOnes(int count)
        {
            return new ServiceResponse(true, "", await _productRepository.GetListBySpec(new ProductSpecification.GetByCreationDate(count)));
        }

        public async Task<ServiceResponse> GetPopular(int count)
        {
            return new ServiceResponse(true, "", await _productRepository.GetListBySpec(new ProductSpecification.GetByShowings(count)));
        }

        public async Task<PaginationResponse<List<ProductDTO>, object>> GetPagedFavoritesProductsAsync(List<int> favoritesId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var specification = new ProductSpecification.GetByFavoritesIds(favoritesId, pageNumber, pageSize);

                var products = await _productRepository.GetListBySpec(specification);

                var totalCount = await _productRepository.GetCountBySpec(new ProductSpecification.GetByFavoritesIds(favoritesId, 1, int.MaxValue));

                var productDTOs = _mapper.Map<List<ProductDTO>>(products);

                return new PaginationResponse<List<ProductDTO>, object>(true, "", payload: productDTOs, pageNumber: pageNumber, pageSize: pageSize, totalCount: totalCount);
            }
            catch (Exception ex)
            {
                return new PaginationResponse<List<ProductDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<PaginationResponse<List<ProductDTO>, object>> GetSearchByName(string name, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var products = await _productRepository.GetListBySpec(new ProductSpecification.GetByNameSearch(name, pageNumber, pageSize));
                var totalCount = await _productRepository.GetCountBySpec(new ProductSpecification.GetByNameSearch(name, 1, int.MaxValue));
                var productDTOs = _mapper.Map<List<ProductDTO>>(products);
                return new PaginationResponse<List<ProductDTO>, object>(true, "", payload: productDTOs, pageNumber: pageNumber, pageSize: pageSize, totalCount: totalCount);
            }
            catch (Exception ex)
            {
                return new PaginationResponse<List<ProductDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<int, object>> GetProductCountAsync()
        {
            try
            {
                var product = await _productRepository.GetAll();
                int shopCount = product.Count();

                return new ServiceResponse<int, object>(true, "Product count retrieved successfully", payload: shopCount);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving product count: {ex.Message}");
                return new ServiceResponse<int, object>(false, "Error retrieving product count");
            }
        }

        public async Task<ServiceResponse<int, object>> GetNewProductsCountAsync()
        {
            try
            {
                int newProductsCount = await _productRepository.GetCountBySpec(new ProductSpecification.GetNewProducts());

                return new ServiceResponse<int, object>(true, "New products count retrieved successfully", payload: newProductsCount);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving new products count: {ex.Message}");
                return new ServiceResponse<int, object>(false, "Error retrieving new products count");
            }
        }

        public async Task<PaginationResponse<List<ProductDTO>, object>> GetNewProducts(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var products = await _productRepository.GetListBySpec(new ProductSpecification.GetNewProducts(pageNumber, pageSize));

                var totalCount = await _productRepository.GetCountBySpec(new ProductSpecification.GetNewProducts());

                var productDTOs = _mapper.Map<List<ProductDTO>>(products);

                return new PaginationResponse<List<ProductDTO>, object>(true, "", payload: productDTOs, pageNumber: pageNumber, pageSize: pageSize, totalCount: totalCount);
            }
            catch (Exception ex)
            {
                return new PaginationResponse<List<ProductDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

    }
}
