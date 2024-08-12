using FM_Rozetka_Api.Core.DTOs.CategoryProduct;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.Seller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategoryProductService _categoryProductService;
       

        public CategoryProductController(ICategoryProductService categoryProductService)
        {
            _categoryProductService = categoryProductService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryProductCreateDTO model)
        {
            var createdApplication = await _categoryProductService.AddAsync(model);
            return Ok(createdApplication.Payload);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _categoryProductService.GetAllAsync();
            return Ok(category);
        }

        [HttpGet("GetAllSorted")]
        public async Task<IActionResult> GetAllSortedAsync()
        {
            var category = await _categoryProductService.GetAllSortedAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryProductService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest("The ID is invalid.");
            }
            return Ok(await _categoryProductService.DeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromForm] CategoryProductUpdateDTO category)
        {
            if (category == null)
            {
                return BadRequest("Category data is invalid.");
            }

            var existingApplication = await _categoryProductService.GetByIdAsync(category.Id);
            if (existingApplication == null)
            {
                return NotFound();
            }

            
            return Ok(await _categoryProductService.UpdateAsync(category));
        }
    }
}
