using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class ModeratorShop : IEntity
    {
        public int Id { get; set; }
        public int ShopId {  get; set; }
        public Shop Shop { get; set; }
        public string AppUserId {  get; set; }
        public AppUser AppUser { get; set; }
    }
}
