
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class UserSignUpEmailDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string SurName { get; set; }
        public string? Phone { get; set; }
    }
}
