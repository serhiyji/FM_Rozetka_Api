using FM_Rozetka_Api.Core.Interfaces;
using Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Product : IEntity
    //Призначення: Зберігає інформацію про продукти, доступні в магазині.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Stars { get; set; }
        public int Stock { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedAt { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        
        public List<Favorite> Favorites { get; set; }
        public bool HasDiscount { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<ProductQuestion> ProductQuestions { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Review> Reviews { get; set; }
        public List<CartItem> CartItems { get; set; }

        public List<PhotoProduct> PhotoProducts { get; set; }

        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }

        public List<Specification> Specifications { get; set; }

        public int CountryProductionId { get; set; }
        public CountryProduction CountryProduction { get; set; }
    }
}
