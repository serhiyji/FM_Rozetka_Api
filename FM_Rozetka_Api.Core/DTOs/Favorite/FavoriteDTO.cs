
namespace FM_Rozetka_Api.Core.DTOs.Favorite
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
