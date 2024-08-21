using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

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
