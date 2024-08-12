using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class CategoryProduct : IEntity
    {
        public int Id { get; set; }
        public int Level {  get; set; }
        public int? TopId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
