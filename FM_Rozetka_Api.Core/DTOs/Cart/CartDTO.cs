using FM_Rozetka_Api.Core.DTOs.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Cart
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
