using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse> CreateUserAsync(CreateUserDTO model);
        Task<ServiceResponse> DeleteUserAsync(DeleteUserDTO model);
        Task<ServiceResponse> EditUserAsync(EditUserDTO model);
        Task<ServiceResponse> ChangeMainInfoUserAsync(EditUserDTO newinfo);
        Task<ServiceResponse> GetUserByIdAsync(string Id);
        Task SendConfirmationEmailAsync(AppUser user);
        Task<ServiceResponse> ConfirmEmailAsync(string userId, string token);
        Task<ServiceResponse> GetAllAsync();
    }
}
