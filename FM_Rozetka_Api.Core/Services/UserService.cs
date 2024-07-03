using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Validation.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper _mapper)
        {
            this._userManager = userManager;
            this._mapper = _mapper;
        }
          public async Task<ServiceResponse> CreateUserAsync(CreateUserDTO model)
        {
            AppUser NewUser = _mapper.Map<CreateUserDTO, AppUser>(model);
            IdentityResult result = await _userManager.CreateAsync(NewUser, "Qwerty-1");
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

            if (user.Email != model.Email)
            {
                user.EmailConfirmed = false;
                user.Email = model.Email;
                user.UserName = model.Email;
                //await SendConfirmationEmailAsync(user);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

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
                bool emailChanged = user.Email != newinfo.Email;
                if (emailChanged)
                {
                    user.EmailConfirmed = false;
                    user.Email = newinfo.Email;
                    user.UserName = newinfo.Email;
                    //await SendConfirmationEmailAsync(user);
                }
                user.LastName = newinfo.LastName;

                user.PhoneNumber = newinfo.PhoneNumber;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    string message = emailChanged ?
                        "Information has been changed and a confirmation email has been sent to the new address." :
                        "Information has been changed";

                    return new ServiceResponse(true, message);
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

            mappedUser.Role = roles[0];
            return new ServiceResponse
            {
                Success = true,
                Message = "User successfully loaded",
                Payload = mappedUser
            };
        }
    }
}
