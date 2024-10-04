using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            this._cartItemService = cartItemService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CartItemCreateDTO cartItemCreateDTO)
        {
            var response = await _cartItemService.Create(cartItemCreateDTO);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _cartItemService.Delete(id));
        }

        [HttpGet("getallbyappuserid")]
        public async Task<IActionResult> GetAllByAppUserId(string Id)
        {
            return Ok(await _cartItemService.GetAllByAppUserId(Id));
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _cartItemService.GetById(Id));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CartItemUpdateDTO cartItemUpdateDTO)
        {
            return Ok(await _cartItemService.Update(cartItemUpdateDTO));
        }

        [HttpGet("setcount")]
        public async Task<IActionResult> SetCount(int Id, int newcount)
        {
            return Ok(await _cartItemService.SetCount(Id, newcount));
        }
    }
}
