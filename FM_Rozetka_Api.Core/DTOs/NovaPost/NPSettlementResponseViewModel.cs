using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.NovaPost
{
    public class NPSettlementResponseViewModel
    {
        public List<NPSettlementItemViewModel> Data { get; set; }
    }
    public class NPSettlementItemViewModel
    {
        public string Ref { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
    }
}
