using FluentValidation.Results;
using FM_Rozetka_Api.Core.DTOs;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
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
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public UserController(IAuthService authService, IUserService userService)
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

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            return Ok(await _userService.ForgotPasswordAsync(email));
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(PasswordRecoveryDto passwordRecoveryDto)
        {
            return Ok(await _userService.ResetPasswordAsync(passwordRecoveryDto));
        }

        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDTO model)
        {
            var result = await _userService.DeleteUserAsync(model);

            if (result.Success)
            {
                return Ok(new { message = "User deleted successfully" });
            }

            return BadRequest(new { message = result.Message, errors = result.Errors });
        }

        [HttpPost("toggleblock")]
        public async Task<IActionResult> ToggleBlockUser([FromBody] string UserId)
        {
            var response = await _userService.ToggleBlockUserAsync(UserId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("UpdatePasswordInfoUser")]
        public async Task<IActionResult> UpdatePasswordInfoUser(UpdatePasswordDto model)
        {
            var validationResult = await new UpdatePasswordValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse result = await _userService.ChangePasswordAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return Ok(result.Errors.FirstOrDefault());
            }
            return Ok(validationResult.Errors.FirstOrDefault());
        }

        [HttpGet("total-user-count")]
        public async Task<IActionResult> GetTotalUserCount()
        {
            var result = await _userService.GetTotalUserCountAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedUserss(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchTerm = null)
        {
            var response = await _userService.GetPagedUsersAsync(pageNumber, pageSize, searchTerm);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("changerole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRoleDTO model)
        {
            var validationResult = await new ChangeUserRoleValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var response = await _userService.ChangeUserRoleAsync(model.UserId, model.NewRole);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }



    }
}
