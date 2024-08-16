using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class ProductQuestion: IEntity
    //Призначення: Зберігає питання користувачів про продукти.
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool OpenQuestion { get; set; } = true;
        public List<ProductAnswer> ProductAnswers { get; set; }
    }
}
