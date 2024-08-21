using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class PhotoProduct : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set;}
        public Product Product { get; set; }
        public string NameImage { get; set; }
    }
}
