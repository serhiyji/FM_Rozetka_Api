using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Specification : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategorySpecificationId { get; set; }
        public CategorySpecification CategorySpecification { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
