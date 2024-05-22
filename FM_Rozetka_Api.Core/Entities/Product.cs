using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<PhotoProduct> PhotoProducts { get; set; }
        public int CategoryProductId { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public List<Specification> Specifications { get; set; }
        public int CountryProductionProductId { get; set; }
        public CountryProductionProduct CountryProductionProduct { get; set; }
        public int ManufacturerProductId { get; set; }
        public ManufacturerProduct ManufacturerProduct { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
