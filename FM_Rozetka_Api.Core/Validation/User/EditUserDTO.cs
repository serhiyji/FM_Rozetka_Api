using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class EditUserDTO
    {
        public string Id { get; set; }
        //public string Email { get; set; }
        //[RegularExpression(@"^(\+?38)?[0-9]+$", ErrorMessage = "Invalid format PhoneNumber.")]
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
