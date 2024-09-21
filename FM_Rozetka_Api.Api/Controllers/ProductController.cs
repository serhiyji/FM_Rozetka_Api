using FM_Rozetka_Api.Api.Models;
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
        private readonly IReviewService _reviewService;
        private readonly IViewedProductService _viewedProductService;
        public ProductController(
                IProductService productService,
                IFavoriteService favoriteService,
                IReviewService reviewService,
                IViewedProductService viewedProductService
            )
        {
            this._productService = productService;
            this._reviewService = reviewService;
            this._viewedProductService = viewedProductService;
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

        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredProducts([FromBody] ModelForFilterProduct model)
        {
            var products = await _productService.FilterProductsBySpecifications(model.Filters, model.Page, model.PageSize);
            return Ok(products);
        }

        [HttpPost("favorite")]
        public async Task<IActionResult> GetFavoriteProducts([FromBody] FavoritesRequest request)
        {
            var response = await _productService.GetPagedFavoritesProductsAsync(request.IdFavorites, request.PageNumber, request.PageSize);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("addviewedproduct")]
        public async Task<IActionResult> AddViewedProduct([FromQuery]int productId, [FromQuery]string appUserId)
        {
            var result = await _viewedProductService.AddProduct(productId, appUserId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getviewedproduct")]
        public async Task<IActionResult> GetViewedProduct([FromQuery]string appUserId, [FromQuery]int count)
        {
            var result = await _viewedProductService.GetByAppUserId(appUserId, count);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrecommendedproducts")]
        public async Task<IActionResult> GetRecommendedProducts([FromQuery]string appUserId, [FromQuery]int count)
        {
            var result = await _viewedProductService.GetRecommendedProducts(appUserId, count);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getnewones")]
        public async Task<IActionResult> GetNewOnes([FromQuery]int count)
        {
            return Ok(await _productService.GetNewOnes(count));
        }

        [HttpGet("getpopular")]
        public async Task<IActionResult> GetPopular([FromQuery]int count)
        {
            return Ok(await _productService.GetPopular(count));
        }

    }
}
