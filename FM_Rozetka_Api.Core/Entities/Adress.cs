using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Adress : IEntity
    {
        public int Id { get; set; }
        public string AppUserId {  get; set; }
        public AppUser AppUser { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Steet { get; set; }
        public string zipcode { get; set; }
    }
}
