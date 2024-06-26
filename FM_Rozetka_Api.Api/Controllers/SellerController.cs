using FM_Rozetka_Api.Core.DTOs;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        public SellerController()
        {
            
        }

        [HttpPost("seller-start")]
        public async Task<IActionResult> SellerStart([FromBody] SellerStartDTO model)
        {
            return Ok();
        }
    }
}
