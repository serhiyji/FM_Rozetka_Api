
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class RegistrationUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
