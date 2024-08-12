using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;

namespace Rozetka_Api.Core.Entities
{
    public class Brand : IEntity
    //Призначення: Зберігає інформацію про бренди продуктів.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<ProductBrand> ProductBrands { get; set; }
    }
}
