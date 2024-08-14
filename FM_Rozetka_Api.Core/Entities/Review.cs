using FM_Rozetka_Api.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FM_Rozetka_Api.Core.Entities
{
    
    public class Review : IEntity
    //Призначення: Зберігає відгуки користувачів про продукти.
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int Rating { get; set; }
        [Required, MaxLength(2048)]
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
