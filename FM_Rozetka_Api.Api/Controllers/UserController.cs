using FluentValidation.Results;
using FM_Rozetka_Api.Core.DTOs;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;
        public UserController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
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

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut(string userId)
        {
            await _authService.DeleteAllRefreshTokenByUserIdAsync(userId);
            ServiceResponse res = await _authService.SignOutAsync();
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("google-register")]
        public async Task<IActionResult> GoogleRegister([FromBody] GoogleTokenModel model)
        {
            var response = await _authService.RegisterWithGoogleAsync(model.TokenId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleTokenModel model)
        {
            var response = await _authService.LoginWithGoogleAsync(model.TokenId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationUserDTO model)
        {
            var response = await _authService.Regitration(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [AllowAnonymous]
        [HttpPost("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request data" });
            }

            Console.WriteLine($"Received request with userId: {request.UserId} and token: {request.Token}");
            var result = await _authService.ConfirmEmailAsync(request.UserId, request.Token);
            if (result.Success)
            {
                return Ok(new { message = "ConfirmEmail successful" });
            }

            return BadRequest(new { message = "Email not confirmed", errors = result.Errors });
        }
        #endregion
        [HttpPost("changemaininfouser")]
        public async Task<IActionResult> ChangeMainInfoUser([FromBody] EditUserDTO model)
        {
            EditUserValidation validator = new EditUserValidation();
            ValidationResult validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse response = await _userService.ChangeMainInfoUserAsync(model);
                return Ok(response);
            }
            return BadRequest(validationResult);
        }
    }
}
