using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Entities.NovaPost
{
    public class Warehouse : IEntity
    {
        [Key]
        public int Id { get; set; }  

        [Required]
        [StringLength(200)]
        public string Ref { get; set; }  

        [Required]
        [StringLength(200)]
        public string Description { get; set; }  

        public int Number { get; set; } 

        [ForeignKey("Settlement")]
        public int SettlementId { get; set; }  

        public virtual Settlement Settlement { get; set; } 
    }
}
