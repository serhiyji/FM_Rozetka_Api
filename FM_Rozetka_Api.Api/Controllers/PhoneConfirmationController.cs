using FM_Rozetka_Api.Core.DTOs.PhoneConfirmation;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FM_Rozetka_Api.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneConfirmationController : Controller
    {
        private readonly IPhoneConfirmationService _phoneConfirmationService;
        public PhoneConfirmationController(IPhoneConfirmationService phoneConfirmationService)
        {
            _phoneConfirmationService = phoneConfirmationService;
        }
        [HttpPost("createconfirmphone")]
        public async Task<IActionResult> CreateConfirmPhone([FromBody] CreateConfirmPhoneDto model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _phoneConfirmationService.CreateConfirmPhone(model));
        }
        [HttpPost("confirmphone")]
        public async Task<IActionResult> ConfirmPhone(ConfirmPhoneDto model)
        {
            return Ok(await _phoneConfirmationService.ConfirmPhone(model));
        }
    }
}
