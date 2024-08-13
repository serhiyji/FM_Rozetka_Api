using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Seller
{
    public class UpdateApplicationStatusRequest
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
