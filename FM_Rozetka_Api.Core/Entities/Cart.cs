using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Cart: IEntity
    //Призначення: Зберігає інформацію про кошики користувачів.
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
