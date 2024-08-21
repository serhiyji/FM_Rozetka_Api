using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class CategorySpecification : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Specification> Specifications { get; set; }
    }
}
