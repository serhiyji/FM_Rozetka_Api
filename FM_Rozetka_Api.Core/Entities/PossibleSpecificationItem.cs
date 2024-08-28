using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class PossibleSpecificationItem : IEntity
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public List<PossibleSpecification> PossibleSpecifications { get; set; }

        public IEnumerable<Specification> Specifications { get; set; }
    }
}
