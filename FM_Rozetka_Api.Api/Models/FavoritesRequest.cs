namespace FM_Rozetka_Api.Api.Models
{
    public class FavoritesRequest
    {
        public List<int> IdFavorites { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
