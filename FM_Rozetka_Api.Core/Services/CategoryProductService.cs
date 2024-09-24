using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    internal class CategoryProductService: ICategoryProductService
    {
        private readonly IRepository<CategoryProduct> _categoryProductRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
    
        public CategoryProductService(IRepository<CategoryProduct> categoryProductRepository, IMapper mapper, IProductService productService)
        {
            _categoryProductRepository = categoryProductRepository;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ServiceResponse<CategoryProduct,object>> AddAsync(CategoryProductCreateDTO application)
        {
            if (application.Level > 1)
            {
                var topCategory = await _categoryProductRepository.GetByID(application.TopId);
                if (topCategory == null )
                {
                    return new ServiceResponse<CategoryProduct, object>(false, "Invalid TopId: No corresponding top-level category found.", payload: topCategory);
                }
            }

            var categoryProduct = _mapper.Map<CategoryProduct>(application);

            await _categoryProductRepository.Insert(categoryProduct);
            await _categoryProductRepository.Save();

            return new ServiceResponse<CategoryProduct, object>(true,"Succes", payload: categoryProduct);
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var categoryProduct = await _categoryProductRepository.GetByID(id);
            if (categoryProduct == null)
            {
                return new ServiceResponse<object, object>(false, $"Category with id {id} not found.");
            }

            var productCount = await _productService.GetCountByCategoryId(id); 
            if (productCount.Payload > 0)
            {
                return new ServiceResponse<object, object>(false, "Cannot delete category because there are associated products.");
            }

            var countSubcategories = await _categoryProductRepository.GetCountBySpec(new CategoryProductSpecification.GetSubCategoriesByTopId(id));
            if(countSubcategories > 0)
            {
                return new ServiceResponse<object, object>(false, "Cannot delete category because there are subcategories.");
            }

            await _categoryProductRepository.Delete(id);
            await _categoryProductRepository.Save();

            return new ServiceResponse<object, object>(true, "Category deleted successfully.",id);
        }

        public async Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetAllAsync()
        {
            var categoryProducts = await _categoryProductRepository.GetAll();
            var categoryProductDTOs = _mapper.Map<IEnumerable<CategoryProductDTO>>(categoryProducts);
            return new ServiceResponse<IEnumerable<CategoryProductDTO>, object>(true, "Success", payload: categoryProductDTOs);
        }

        public async Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetAllSortedAsync()
        {
            var categoryProducts = await _categoryProductRepository.GetAll();
            var categoryProductDTOs = _mapper.Map<IEnumerable<CategoryProductDTO>>(categoryProducts);

            var hierarchy = BuildCategoryHierarchy(categoryProductDTOs);

            return new ServiceResponse<IEnumerable<CategoryProductDTO>, object>(true, "Success", payload: hierarchy);
        }

        private IEnumerable<CategoryProductDTO> BuildCategoryHierarchy(IEnumerable<CategoryProductDTO> categories)
        {
            var categoryLookup = categories.ToLookup(c => c.TopId);

            var rootCategories = categoryLookup[null].ToList();

            foreach (var category in rootCategories)
            {
                category.SubCategories = BuildHierarchy(category.Id, categoryLookup);
            }

            return rootCategories;
        }

        private List<CategoryProductDTO> BuildHierarchy(int parentId, ILookup<int?, CategoryProductDTO> lookup)
        {
            var subCategories = lookup[parentId].ToList();

            foreach (var subCategory in subCategories)
            {
                subCategory.SubCategories = BuildHierarchy(subCategory.Id, lookup);
            }

            return subCategories;
        }

        public async Task<ServiceResponse<CategoryProductDTO, object>> GetByIdAsync(int id)
        {
            var categoryProduct = await _categoryProductRepository.GetByID(id);
            if (categoryProduct == null)
            {
                return new ServiceResponse<CategoryProductDTO, object>(false, $"Category with id {id} not found.");
            }

            var categoryProductDTO = _mapper.Map<CategoryProductDTO>(categoryProduct);
            return new ServiceResponse<CategoryProductDTO, object>(true, "Success", payload: categoryProductDTO);
        }


        public async Task<ServiceResponse<object, object>> UpdateAsync(CategoryProductUpdateDTO model)
        {
            var categoryProduct = await _categoryProductRepository.GetByID(model.Id);
            if (categoryProduct == null)
            {
                return new ServiceResponse<object, object>(false, $"Category with id {model.Id} not found.");
            }

            categoryProduct.Name = model.Name;
            categoryProduct.Description = model.Description;

            await _categoryProductRepository.Update(categoryProduct);
            await _categoryProductRepository.Save();

            return new ServiceResponse<object, object>(true, "Category updated successfully.",payload: categoryProduct);
        }

        public async Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetFirstLevelCategoriesAsync()
        {
            var categories = await _categoryProductRepository.GetListBySpec(new CategoryProductSpecification.GetFirstLevelCategories());
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryProductDTO>>(categories);

            return new ServiceResponse<IEnumerable<CategoryProductDTO>, object>(true, "Category 1 lvl received successfully.", payload: categoryDTOs);
        }

        public async Task<ServiceResponse<IEnumerable<CategoryProductDTO>, object>> GetSubCategoriesByTopIdAsync(int topId)
        {
            var categories = await _categoryProductRepository.GetListBySpec(new CategoryProductSpecification.GetSubCategoriesByTopId(topId));
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryProductDTO>>(categories);

            return new ServiceResponse<IEnumerable<CategoryProductDTO>, object>(true, $"Subcategories for category with ID  {topId} successfully retrieved", payload: categoryDTOs);
        }
    }
}
