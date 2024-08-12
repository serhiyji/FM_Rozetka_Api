
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public string LockedOut { get; set; } = string.Empty;
        public bool LockoutEnabled { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string ConfirmPassword {  get; set; } = string.Empty;
    }
}
