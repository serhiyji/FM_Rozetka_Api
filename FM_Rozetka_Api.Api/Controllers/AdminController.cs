using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpPost("createadmin")]
        public async Task<IActionResult> Create([FromBody]CreateUserDTO model)
        {
            CreateUserValidation validator = new CreateUserValidation();
            ValidationResult validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                model.Role = "Administrator";
                return Ok(await _userService.CreateUserAsync(model));
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("deleteadmin")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserDTO model)
        {
            var res = await _userService.DeleteUserAsync(model);
            return Ok(res);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_userService.GetAllAsync());
        }
    }
}