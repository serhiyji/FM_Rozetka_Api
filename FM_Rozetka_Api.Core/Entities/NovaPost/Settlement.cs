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
    public class Settlement : IEntity
    {
        [Key]
        public int Id { get; set; }  

        [Required]
        [StringLength(200)]
        public string Ref { get; set; }  

        [Required]
        [StringLength(200)]
        public string Description { get; set; }  

        [ForeignKey("Area")]
        public int AreaId { get; set; } 

        public virtual Area Area { get; set; }  

        public virtual ICollection<Warehouse> Warehouses { get; set; }  
    }

}
