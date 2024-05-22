using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class CartItem: IEntity
    //Призначення: Зберігає інформацію про продукти в кошику користувача.
    {
        public int Id{ get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
