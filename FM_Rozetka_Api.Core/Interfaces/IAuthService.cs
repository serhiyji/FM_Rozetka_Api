using FM_Rozetka_Api.Core.DTOs.Token;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Services;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse> LoginUserAsync(UserLoginDTO model);
        Task<ServiceResponse> LoginUserByPhoneAsync(UserLoginPhoneDTO model);
        Task<ServiceResponse> SignOutAsync();
        Task<ServiceResponse> SingUpByEmailAsync(UserSignUpEmailDTO model);
        Task DeleteAllRefreshTokenByUserIdAsync(string userId);
        Task<ServiceResponse> ConfirmEmailAsync(string userId, string token);
        Task SendConfirmationEmailAsync(AppUser user);
        Task<ServiceResponse> LoginWithGoogleAsync(string tokenId);
        Task<ServiceResponse> RegisterWithGoogleAsync(string tokenId);
        Task<ServiceResponse> Regitration(RegistrationUserDTO regitrationUserDTO);
    }
}
