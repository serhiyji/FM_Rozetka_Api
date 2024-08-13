using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

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
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> ForgotPasswordAsync(string email);
        Task<ServiceResponse> ResetPasswordAsync(PasswordRecoveryDto model);
        Task<ServiceResponse> BanUser(string AppUserId);
        ServiceResponse<List<UserDTO>, object> GetAllAsync();
        Task<ServiceResponse> ChangePasswordAsync(UpdatePasswordDto model);
    }
}
