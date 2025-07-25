﻿using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities
{
    public class Shop : IEntity
    {
        public int Id { get; set; }
        public List<ModeratorShop> ModeratorShop { get; set; }
        public List<Product> Products { get; set; }
        // Owner
        public string AppUserId {  get; set; }
        public AppUser AppUser { get; set; }


        // Fields from SellerApplication

        public int CompanyId { get; set; }  
        public Company Company { get; set; }

        public string Website { get; set; }
        public bool HasNoWebsite { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNonResident { get; set; }
    }
}
