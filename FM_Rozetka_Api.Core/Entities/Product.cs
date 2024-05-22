using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
        public ICollection<ProductBrand> ProductBrands { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<ProductQuestion> ProductQuestions { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

        public List<PhotoProduct> PhotoProducts { get; set; }

        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }

        public List<Specification> Specifications { get; set; }

        public int CountryProductionProductId { get; set; }
        public CountryProductionProduct CountryProductionProduct { get; set; }
    }
}
