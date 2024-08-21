using FM_Rozetka_Api.Core.Interfaces;


namespace FM_Rozetka_Api.Core.Entities
{
    public class Payment: IEntity
    //Призначення: Зберігає інформацію про платежі за замовлення
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
