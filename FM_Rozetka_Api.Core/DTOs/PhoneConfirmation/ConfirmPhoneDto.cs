using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.PhoneConfirmation
{
    public class ConfirmPhoneDto
    {
        public string userid { get; set; }
        public string confirmationCode { get; set; }
    }
}
