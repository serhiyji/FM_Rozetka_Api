using FM_Rozetka_Api.Core.Interfaces;
using Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace FM_Rozetka_Api.Core.Entities
{
    public class ProductBrand : IEntity
    //Призначення: Відображає зв'язок між продуктами та брендами.
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
