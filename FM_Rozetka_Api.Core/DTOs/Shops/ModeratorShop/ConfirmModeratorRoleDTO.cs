using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop
{
    public class ConfirmModeratorRoleDTO
    {
        public int ShopId { get; set; }
        public string AppUserId { get; set; }
        public string token { get; set; }

    }
}
