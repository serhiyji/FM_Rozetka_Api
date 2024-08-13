using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop
{
    public class ModeratorShopUpdateDTO
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string AppUserId { get; set; }
    }
}
