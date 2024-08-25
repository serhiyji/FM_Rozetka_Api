using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Specification : IEntity
    {
        public int Id { get; set; }
        public int PossibleSpecificationItemId { get; set; }
        public PossibleSpecificationItem PossibleSpecificationItem { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
