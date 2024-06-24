using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramAPIController : Controller
    {
        public readonly ITelegramApiHandlerService _ITelegramAPIService;
        private readonly IConfiguration _configuration;

        public TelegramAPIController(ITelegramApiHandlerService ITelegramAPIService, IConfiguration configuration)
        {
            _ITelegramAPIService = ITelegramAPIService;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_configuration["TelegramAPI:AccessToken"]);
        }
    }
}
