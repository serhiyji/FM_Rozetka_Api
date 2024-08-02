using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Validation.Shop;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
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
    }
}
