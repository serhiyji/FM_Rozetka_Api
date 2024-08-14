using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            return Ok(await _brandService.GetAllAsync(page, pageSize));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _brandService.GetAsync(id));
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create(BrandCreateDTO brandCreateDTO)
        {
            return Ok(await _brandService.AddAsync(brandCreateDTO));
        }

        [HttpPost("upadte")]
        public async Task<IActionResult> Update(BrandUpdateDTO brandUpdateDTO)
        {
            return Ok(await _brandService.UpdateAsync(brandUpdateDTO));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _brandService.DeleteAsync(id));
        }
    }
}
