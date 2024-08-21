using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFavoriteService _favoriteService;
        private readonly IReviewService _reviewService;
        public ProductController(
                IProductService productService,
                IFavoriteService favoriteService,
                IReviewService reviewService
            )
        {
            this._productService = productService;
            this._favoriteService = favoriteService;
            this._reviewService = reviewService;
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

        #region Favorite

        [HttpPost("addproducttofavorites")]
        public async Task<IActionResult> AddProductToFavorites(FavoriteCreateDTO favoriteCreateDTO)
        {
            return Ok(await _favoriteService.AddAsync(favoriteCreateDTO));
        }

        [HttpPost("deleteproductfromfavorites")]
        public async Task<IActionResult> DeleteProductFromFavorites(int id)
        {
            return Ok(await _favoriteService.DeleteAsync(id));
        }

        [HttpGet("getallfavorites")]
        public async Task<IActionResult> GetAllFavorites(string appUserId)
        {
            return Ok(await _favoriteService.GetAllAsync(appUserId));
        }

        #endregion

    }
}