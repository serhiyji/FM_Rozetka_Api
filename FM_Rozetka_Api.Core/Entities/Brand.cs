using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozetka_Api.Core.Entities
{
    public class Brand : IEntity
    //Призначення: Зберігає інформацію про бренди продуктів.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductBrand> ProductBrands { get; set; }
    }
}
