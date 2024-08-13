using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class ProductAnswer: IEntity
    {
        public int Id { get; set; }
        public int QuestionID { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string AnswerText { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductQuestion ProductQuestion { get; set; }
    }
}
