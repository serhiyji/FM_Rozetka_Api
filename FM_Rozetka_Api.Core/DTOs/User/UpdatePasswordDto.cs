
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class UpdatePasswordDto
    {
        public string Id { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
