using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            this._favoriteService = favoriteService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> AddProductToFavorites([FromForm] FavoriteCreateDTO favoriteCreateDTO)
        {
            var response = await _favoriteService.AddAsync(favoriteCreateDTO);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProductFromFavorites(int id)
        {
            return Ok(await _favoriteService.DeleteAsync(id));
        }

        [HttpGet("getallByUserId")]
        public async Task<IActionResult> GetAllFavorites([FromQuery] string appUserId)
        {
            return Ok(await _favoriteService.GetAllAsync(appUserId));
        }

    }
}
