using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovaPoshtaController : ControllerBase
    {
        private readonly INovaPoshtaService _novaPoshtaService;

        public NovaPoshtaController(INovaPoshtaService novaPoshtaService)
        {
            _novaPoshtaService = novaPoshtaService;
        }

        [HttpGet("areas")]
        public async Task<IActionResult> GetAreas()
        {
            var response = await _novaPoshtaService.GetAreas();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("settlements")]
        public async Task<IActionResult> GetSettlements()
        {
            var response = await _novaPoshtaService.GetSettlements();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("warehouses")]
        public async Task<IActionResult> GetWarehouses()
        {
            var response = await _novaPoshtaService.GetWarehouses();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("settlements/search")]
        public async Task<IActionResult> SearchSettlements([FromQuery] string areaRef, [FromQuery] string description = null)
        {
            var response = await _novaPoshtaService.SearchSettlements(areaRef, description);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("warehouses/search")]
        public async Task<IActionResult> SearchWarehouses([FromQuery] string settlementRef, [FromQuery] string description = null)
        {
            var response = await _novaPoshtaService.SearchWarehouses(settlementRef, description);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("areas/all")]
        public async Task<IActionResult> GetAllAreas()
        {
            var response = await _novaPoshtaService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
