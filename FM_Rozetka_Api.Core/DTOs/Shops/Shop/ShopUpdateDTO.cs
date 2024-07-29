﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Shops.Shop
{
    public class ShopUpdateDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNonResident { get; set; }
    }
}
