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
        Task<ServiceResponse> ToggleBlockUserAsync(string userId);
        Task<ServiceResponse> ChangeUserRoleAsync(string userId, string newRole);
        ServiceResponse<List<UserDTO>, object> GetAllAsync();
        Task<ServiceResponse> ChangePasswordAsync(UpdatePasswordDto model);
        Task<ServiceResponse<int, object>> GetTotalUserCountAsync();
        Task<PaginationResponse<List<UserDTO>, object>> GetPagedUsersAsync(int page = 1, int pageSize = 10, string searchTerm = null);
    }
}
