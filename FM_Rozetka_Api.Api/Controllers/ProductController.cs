using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("createproduct")]
        public async Task<IActionResult> Create([FromForm] ProductCreateDTO model)
        {
                return Ok(await _productService.AddAsync(model));   
        }
    }
}
