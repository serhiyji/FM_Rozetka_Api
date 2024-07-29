using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.ModeratorShop;
using FM_Rozetka_Api.Core.Validation.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeratorShopController : ControllerBase
    {
        private readonly IModeratorShopService _moderatorShopService;


        public ModeratorShopController(IModeratorShopService moderatorShopService)
        {
            _moderatorShopService = moderatorShopService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateModeratorShop([FromBody] ModeratorShopCreateDTO model)
        {
            var validationResult = await new ModeratorShopCreateValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var response = await _moderatorShopService.AddAsync(model);
                return Ok(response);
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllModeratorShop()
        {
            var moderatorShop = await _moderatorShopService.GetAllAsync();
            return Ok(moderatorShop);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdModeratorShop(int id)
        {
            if (id != null)
            {
                var moderatorShop = await _moderatorShopService.GetAllAsync();
                return Ok(moderatorShop);
            }
            return BadRequest("The id must not be null");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication([FromBody] ModeratorShopUpdateDTO model)
        {
            if (model == null)
            {
                return BadRequest("ModeratorShop data is invalid.");
            }

            var existingShop = await _moderatorShopService.GetByIdAsync(model.Id);
            if (existingShop == null)
            {
                return NotFound();
            }

            await _moderatorShopService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var application = await _moderatorShopService.GetByIdAsync(id);
            if (application == null)
            {
                return BadRequest("The id must not be null");
            }

            await _moderatorShopService.DeleteAsync(id);
            return NoContent();
        }
    }
}

