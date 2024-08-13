using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class CartItem: IEntity
    //Призначення: Зберігає інформацію про продукти в кошику користувача.
    {
        public int Id{ get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser{ get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
