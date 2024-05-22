using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Favorite: IEntity
    //Призначення: Зберігає продукти, додані користувачами до списку улюблених.
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime AddedAt { get; set; }

        public AppUser User { get; set; }
        public Product Product { get; set; }
    }
}
