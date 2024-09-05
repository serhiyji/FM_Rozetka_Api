using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities.NovaPost
{
    public class Area : IEntity
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(255)]
        public string Ref { get; set; }  

        [Required]
        [StringLength(255)]
        public string Description { get; set; }  

        public virtual ICollection<Settlement> Settlements { get; set; }  
    }
}
