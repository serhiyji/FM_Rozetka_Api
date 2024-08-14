
namespace FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion
{
    public class ProductQuestionCreateDTO
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
