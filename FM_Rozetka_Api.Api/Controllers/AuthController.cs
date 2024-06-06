using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        #region Auth

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO model)
        {
            var validationResult = await new LoginUserValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse response = await _authService.LoginUserAsync(model);
                return Ok(response);
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }

        //[AllowAnonymous]
        //[HttpPost("login")]
        //public async Task<IActionResult> LoginUserPhone([FromBody] UserLoginPhoneDTO model)
        //public async Task<IActionResult> LoginUserPhone([FromBody] UserLoginDTO model)
        //{
        //    var validationResult = await new LoginUserValidation().ValidateAsync(model);
        //    if (validationResult.IsValid)
        //    {
        //        ServiceResponse response = await _authService.LoginUserByPhoneAsync(model);
        //        return Ok(response);
        //    }
        //    return BadRequest(validationResult.Errors.FirstOrDefault());
        //}

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut(string userId)
        {
            await _authService.DeleteAllRefreshTokenByUserIdAsync(userId);
            ServiceResponse res = await _authService.SignOutAsync();
            return Ok(res);
        }

        #endregion
    }
}
