using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Rozetka_Api.Core.Entities
{
    public class Brand : IEntity
    //Призначення: Зберігає інформацію про бренди продуктів.
    {
        public int Id { get; set; }
        [Required, MaxLength(256)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Product> Products { get; set; }
    }
}
