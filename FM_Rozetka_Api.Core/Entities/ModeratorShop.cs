using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class ModeratorShop : IEntity
    {
        public int Id { get; set; }
        public int ShopId {  get; set; }
        public Shop Shop { get; set; }
        public string AppUserId {  get; set; }
        public AppUser AppUser { get; set; }
    }
}
