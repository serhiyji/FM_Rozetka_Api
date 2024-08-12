
namespace FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer
{
    public class ProductAnswerDTO
    {
        public int Id { get; set; }
        public int QuestionID { get; set; }
        public string AppUserId { get; set; }
        public string AnswerText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
