using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class OrderStatusHistory: IEntity
    //Призначення: Зберігає історію змін статусу замовлення.
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }

    }
}
