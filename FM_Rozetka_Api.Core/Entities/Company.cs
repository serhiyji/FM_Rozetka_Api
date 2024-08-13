using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Shop> Shops { get; set; }
    }
}
