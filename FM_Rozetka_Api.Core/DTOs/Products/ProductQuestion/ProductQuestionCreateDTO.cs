
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion
{
    public class ProductQuestionCreateDTO
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool OpenQuestion { get; set; } = true;
        public bool hasAnswer { get; set; } 
    }
}
