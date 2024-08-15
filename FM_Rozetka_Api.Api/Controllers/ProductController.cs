using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateDTO model)
        {
            var response = await _productService.AddAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateDTO model)
        {
            var response = await _productService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getbyshopid")]
        public async Task<IActionResult> GetByShopId(int shopid)
        {
            var response = await _productService.GetByShopIdAsync(shopid);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _productService.GetPagedProductsAsync(pageNumber, pageSize);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }
}
