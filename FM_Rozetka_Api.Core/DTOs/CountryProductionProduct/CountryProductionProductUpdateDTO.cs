using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.CountryProductionProduct
{
    public class CountryProductionProductUpdateDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CountryProductionId { get; set; }
    }
}
