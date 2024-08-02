using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public UserService(
                IEmailService emailService,
                UserManager<AppUser> userManager,
                IMapper _mapper,
                IConfiguration configuration
            )
        {
            this._userManager = userManager;
            this._mapper = _mapper;
            this._configuration = configuration;
            this._emailService = emailService;
        }
        public async Task<ServiceResponse> CreateUserAsync(CreateUserDTO model)
        {
            AppUser NewUser = _mapper.Map<CreateUserDTO, AppUser>(model);
            NewUser.UserName = model.Email;
            IdentityResult result = await _userManager.CreateAsync(NewUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(NewUser, model.Role);
                //await SendConfirmationEmailAsync(NewUser);
                return new ServiceResponse(true, "User has been added");
            }
            return new ServiceResponse(false, "Something went wrong", errors: result.Errors.Select(e => e.Description));
        }
        public async Task<ServiceResponse> DeleteUserAsync(DeleteUserDTO model)
        {
            AppUser userdelete = await _userManager.FindByIdAsync(model.Id);
            if (userdelete == null)
            {
                return new ServiceResponse(false, "User a was found");
            }
            IdentityResult result = await _userManager.DeleteAsync(userdelete);
            if (result.Succeeded)
            {
                return new ServiceResponse(true);
            }
            return new ServiceResponse(false, "something went wrong", errors: result.Errors.Select(e => e.Description));
        }
        public async Task<ServiceResponse> EditUserAsync(EditUserDTO model)
        {
            AppUser? user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.", errors: new List<string>() { "User not found." });
            }

            user.FirstName = model.FirstName;
            user.SurName = model.SurName;
            user.LastName = model.LastName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ServiceResponse(true, "User successfully updated.");
            }
            return new ServiceResponse(false, "Something went wrong", errors: result.Errors.Select(e => e.Description));
        }
        public async Task<ServiceResponse> ChangeMainInfoUserAsync(EditUserDTO newinfo)
        {
            AppUser user = await _userManager.FindByIdAsync(newinfo.Id);

            if (user != null)
            {
                user.FirstName = newinfo.FirstName;
                user.SurName = newinfo.SurName;
                user.LastName = newinfo.LastName;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return new ServiceResponse(true, "Information has been changed");
                }
                else
                {
                    return new ServiceResponse(false, "Something went wrong", errors: result.Errors.Select(e => e.Description));
                }
            }
            return new ServiceResponse(false, "Not found user");
        }
        public async Task<ServiceResponse> GetUserByIdAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            UpdateUserDTO mappedUser = _mapper.Map<AppUser, UpdateUserDTO>(user);
            return new ServiceResponse(true, "User successfully loaded", payload: mappedUser);
        }
        public async Task<ServiceResponse> GetAllAsync()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<UserDTO> mappedUsers = users.Select(u => _mapper.Map<AppUser, UserDTO>(u)).ToList();

            return new ServiceResponse
            {
                Success = true,
                Message = "All users loaded.",
                Payload = mappedUsers
            };
        }

        #region Confirm email and send token for confirm email
        public async Task SendConfirmationEmailAsync(AppUser user)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            byte[] encodedToken = Encoding.UTF8.GetBytes(token);
            string validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["HostSettings:URL"]}/Login/confirmemail?userid={user.Id}&token={validEmailToken}";

            string emailBody = $"<h1>Confirm your email</h1> <a href='{url}'>Confirm now!</a>";
            await _emailService.SendEmailAsync(user.Email, "Email confirmation.", emailBody);
        }

        public async Task<ServiceResponse> ConfirmEmailAsync(string userId, string token)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found");
            }

            byte[] decodedToken = WebEncoders.Base64UrlDecode(token);
            string narmalToken = Encoding.UTF8.GetString(decodedToken);

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, narmalToken);
            if (result.Succeeded)
            {
                return new ServiceResponse(true, "Email successfully confirmed.");
            }
            return new ServiceResponse(false, "Email not confirmed", errors: result.Errors.Select(e => e.Description));
        }
        #endregion

        #region Password recovery and send token for password recovery
        public async Task<ServiceResponse> ForgotPasswordAsync(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.");
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            byte[] encodedToken = Encoding.UTF8.GetBytes(token);
            string validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["HostSettings:URL"]}/Dashboard/ResetPassword?email={email}&token={validEmailToken}";

            string emailBody = $"<h1>Follow the instruction for reset password.</h1><a href='{url}'>Reset now!</a>";
            await _emailService.SendEmailAsync(email, "Reset password for TopNews.", emailBody);

            return new ServiceResponse(true, "Email successfull send.");
        }

        public async Task<ServiceResponse> ResetPasswordAsync(PasswordRecoveryDto model)
        {
            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.");
            }

            byte[] decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string narmalToken = Encoding.UTF8.GetString(decodedToken);
            IdentityResult res = await _userManager.ResetPasswordAsync(user, narmalToken, model.Password);
            if (res.Succeeded)
            {
                return new ServiceResponse(true, "Password changed successfully");
            }
            return new ServiceResponse(false, "Something went wrong", errors: res.Errors.Select(e => e.Description));
        }
        #endregion
    }
}
