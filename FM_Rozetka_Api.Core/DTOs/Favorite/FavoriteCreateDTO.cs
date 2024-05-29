using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Favorite
{
    public class FavoriteCreateDTO
    {
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
