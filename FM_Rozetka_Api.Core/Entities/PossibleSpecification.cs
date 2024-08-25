using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class PossibleSpecification : IEntity
    {
        public int Id { get; set; }

        public int CategoryProductId {  get; set; }
        public CategoryProduct CategoryProduct { get; set; }

        public int CategorySpecificationId { get; set; }
        public CategorySpecification CategorySpecification { get; set; }

        public int PossibleSpecificationItemId { get; set; }
        public PossibleSpecificationItem PossibleSpecificationItem { get; set; }
    }
}
