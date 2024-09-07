using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.NovaPost
{
    public class NPAreaResponseViewModel
    {
        public List<NPAreaItemViewModel> Data { get; set; }
    }
    public class NPAreaItemViewModel
    {
        public string Ref { get; set; }
        public string Description { get; set; }
    }
}
