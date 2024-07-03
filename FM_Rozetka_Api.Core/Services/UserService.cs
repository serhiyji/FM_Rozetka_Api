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

    }
}
