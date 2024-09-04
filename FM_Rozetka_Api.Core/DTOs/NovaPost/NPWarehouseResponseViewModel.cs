using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.NovaPost
{
    public class NPWarehouseResponseViewModel
    {
        public List<NPWarehouseItemViewModel> Data { get; set; }
    }
    public class NPWarehouseItemViewModel
    {
        public string Ref { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public string SettlementRef { get; set; }
    }
}
