using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.DTOs.Company;
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
    public class CategoryProductService: ICategoryProductService
    {
        private readonly IRepository<CategoryProduct> _categoryProductRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
    
        public CategoryProductService(IRepository<CategoryProduct> categoryProductRepository, IMapper mapper, IRepository<Product> productRepository)
        {
            _categoryProductRepository = categoryProductRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<CategoryProduct,object>> AddAsync(CategoryProductCreateDTO application)
        {
            if (application.Level > 1)
            {
                var topCategory = await _categoryProductRepository.GetByID(application.PreviousСategoryId);
                if (topCategory == null || topCategory.Level != 1)
                {

                    return new ServiceResponse<CategoryProduct, object>(false, "Invalid TopId: No corresponding top-level category found.", payload: topCategory);
                }
            }

            var categoryProduct = _mapper.Map<CategoryProduct>(application);

            await _categoryProductRepository.Insert(categoryProduct);
            await _categoryProductRepository.Save();

            return new ServiceResponse<CategoryProduct, object>(true,"Succes", payload: categoryProduct);
        }

        public async Task DeletenAsync(int id)
        {
            var categoryproduct = await _categoryProductRepository.GetByID(id);
            if (categoryproduct == null)
            {
                throw new ArgumentException($"Category with id {id} not found.");
            }

            var productCount = await _productRepository.GetCountRows();/// ?????????????????//шзх???????
            if (productCount > 0)
            {
                throw new InvalidOperationException("Cannot delete category because there are associated products.");
            }

            await _categoryProductRepository.Delete(id);
            await _categoryProductRepository.Save();
        }


        public async Task<IEnumerable<CategoryProductDTO>> GetAllAsync()
        {
            var categoryproduct = await _categoryProductRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryProductDTO>>(categoryproduct);
        }

        public async Task<CategoryProductDTO> GetByIdAsync(int id)
        {
            var categoryproduct = await _categoryProductRepository.GetByID(id);
            return _mapper.Map<CategoryProductDTO>(categoryproduct);
        }

        public async Task UpdateAsync(CategoryProductUpdateDTO model)
        {
            var categoryproducts = await GetByIdAsync(model.Id);
            categoryproducts.Name = model.Name;
            categoryproducts.Description = model.Description;  
            var categoryproduct = _mapper.Map<CategoryProduct>(categoryproducts);
            await _categoryProductRepository.Update(categoryproduct);
            await _categoryProductRepository.Save();
        }
    }
}
