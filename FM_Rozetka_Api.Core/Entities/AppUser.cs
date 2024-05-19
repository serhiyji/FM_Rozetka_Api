using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FM_Rozetka_Api.Core.Entities
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(64)]
        public string SurName { get; set; } = string.Empty;
        [Required, MaxLength(64)]
        public string LastName { get; set; } = string.Empty;
    }
}
