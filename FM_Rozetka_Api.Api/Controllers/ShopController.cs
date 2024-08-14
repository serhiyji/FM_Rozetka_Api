using FM_Rozetka_Api.Core.DTOs.Shops;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Validation.ModeratorShop;
using FM_Rozetka_Api.Core.Validation.Seller;
using FM_Rozetka_Api.Core.Validation.Shop;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly IModeratorShopService _moderatorShopService;

        public ShopController(IShopService shopService, IModeratorShopService moderatorShopService)
        {
            _shopService = shopService;
            _moderatorShopService = moderatorShopService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateShop([FromBody] ShopCreateDTO model)
        {
            var validationResult = await new CreateShopValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var response = await _shopService.AddAsync(model);
                return Ok(response);
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllShop()
        {
            var shops = await _shopService.GetAllAsync();
            return Ok(shops);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdShop([FromBody] int id)
        {
            if (id != null)
            {
                var shops = await _shopService.GetAllAsync();
                return Ok(shops);
            }
            return BadRequest("The id must not be null");
        }

        [HttpGet("GetShopByUserId")]
        public async Task<IActionResult> GetByUserIdShop(string id)
        {
            if (id != null)
            {
                var shops = await _shopService.GetByUserIdAsync(id);
                return Ok(shops);
            }
            return BadRequest("The id must not be null");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication([FromBody] ShopUpdateDTO model)
        {
            if (model == null)
            {
                return BadRequest("Shop data is invalid.");
            }

            var validationResult = await new UpdateShopValidation().ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingShop = await _shopService.GetByIdAsync(model.Id);
            if (existingShop == null)
            {
                return NotFound();
            }

            await _shopService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var application = await _shopService.GetByIdAsync(id);
            if (application == null)
            {
                return BadRequest("The id must not be null");
            }

            await _shopService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("AddModeratorShop")]
        public async Task<IActionResult> CreateModeratorShop([FromForm] CreateModeratorUserDTO model)
        {
            var validationResult = await new CreateModeratorUserValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var response = await _moderatorShopService.AddModeratorShopAsync(model);
                return Ok(response);
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }

        [HttpGet("GetUsersByIdShop")]
        public async Task<IActionResult> GetUsersByIdShop([FromQuery] int shopId)
        {
            try
            {
                if (shopId != 0)
                {
                    var shops = await _moderatorShopService.GetUsersByShopId(shopId);
                    return Ok(shops);
                }
                return BadRequest("The shopId must not be null");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ConfirmModeratorRole")]
        public async Task<IActionResult> ConfirmModeratorRole([FromForm] ConfirmModeratorRoleDTO model)
        {
            var validationResult = await new ConfirmModeratorRoleValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var response = await _moderatorShopService.ConfirmModeratorRoleAsync(model);
                return Ok(response);
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }

        [HttpDelete("DeleteModeratorShop/{id}")]
        public async Task<IActionResult> DeleteModeratorShop(int id)
        {
            var ModeratorShop = await _moderatorShopService.GetByIdAsync(id);
            if (ModeratorShop == null)
            {
                return BadRequest("The id must not be null");
            }

            await _moderatorShopService.DeleteAsync(id);
            return NoContent();
        }


    }
}
