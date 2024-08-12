
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class EditUserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
