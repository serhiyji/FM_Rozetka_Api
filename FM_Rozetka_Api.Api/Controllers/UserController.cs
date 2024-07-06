using FluentValidation.Results;
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
        public readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("changemaininfouser")]
        public async Task<IActionResult> ChangeMainInfoUser(EditUserDTO model)
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
