using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class ChangeUserRoleDTO
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
    }
}
