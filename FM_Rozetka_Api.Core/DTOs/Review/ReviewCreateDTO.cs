
namespace FM_Rozetka_Api.Core.DTOs.Review
{
    public class ReviewCreateDTO
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
