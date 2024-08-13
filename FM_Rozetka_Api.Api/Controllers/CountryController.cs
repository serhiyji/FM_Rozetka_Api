using FM_Rozetka_Api.Core.DTOs.CountryProduction;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //CountryProductionService

        private readonly ICountryProductionService _countryProductionService;

        public CountryController(ICountryProductionService countryProductionService)
        {
            this._countryProductionService = countryProductionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CountryProductionCreateDTO model)
        {
            if (model.Name != null)
            {
                var response = await _countryProductionService.AddAsync(model);
                if (response.Success)
                {
                    return Ok(response.Payload);
                }
                return BadRequest(response.Message);
            }
            return BadRequest("The country name must not be empty");
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryProductionService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryProductionService.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _countryProductionService.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound("Country not found");
            }
            return Ok(country);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CountryProductionUpdateDTO model)
        {
            var response = await _countryProductionService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response.Payload);
            }
            return BadRequest(response.Message);
        }

    }
}
