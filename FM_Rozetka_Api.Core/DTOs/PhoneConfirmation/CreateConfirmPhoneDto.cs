using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.PhoneConfirmation
{
    public class CreateConfirmPhoneDto
    {
        public string AppUserId { get; set; }
        public string Phone { get; set; }
    }
}
