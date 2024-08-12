using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class OrderItem: IEntity
    //Призначення: Зберігає інформацію про продукти, включені в кожне замовлення.
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
