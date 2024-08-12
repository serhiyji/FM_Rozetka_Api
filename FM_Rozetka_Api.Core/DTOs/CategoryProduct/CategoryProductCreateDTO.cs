
namespace FM_Rozetka_Api.Core.DTOs.CategoryProduct
{
    public class CategoryProductCreateDTO
    {
        public int Level { get; set; }
        public int? TopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PreviousСategoryId { get; set; }
    }
}
