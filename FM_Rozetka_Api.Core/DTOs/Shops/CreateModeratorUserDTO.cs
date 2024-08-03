using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Shops
{
    public class CreateModeratorUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public int ShopId { get; set; }
    }
}
