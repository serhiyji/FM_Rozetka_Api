namespace FM_Rozetka_Api.Api.Models
{
    public class ModelForFilterProduct
    {
        public Dictionary<int, List<int>> Filters { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
