using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Validation.User
{
    public class DeleteUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
