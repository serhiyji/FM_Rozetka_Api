using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace FM_Rozetka_Api.Api.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        public AdminController(UserService userService)
        {
               this._userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Create admin page
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDTO model)
        {
            CreateUserValidation validator = new CreateUserValidation();
            ValidationResult validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse response = await _userService.CreateUserAsync(model);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CreateUserError = response.Errors.FirstOrDefault();
                return View();
            }
            ViewBag.CreateUserError = validationResult.Errors.FirstOrDefault();
            return View();
        }
        #endregion

﻿using FluentValidation.Results;
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
