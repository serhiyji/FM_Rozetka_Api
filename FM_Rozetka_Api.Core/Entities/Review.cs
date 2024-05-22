using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    
    public class Review:IEntity
    //Призначення: Зберігає відгуки користувачів про продукти.
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; }
        public AppUser User { get; set; }
    }
}
