using FM_Rozetka_Api.Core.Entities.NovaPost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.NovaPost
{
    public class SettlementDTO
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
    }
}
