using FM_Rozetka_Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Entities
{
    public class ProductQuestion: IEntity
    //Призначення: Зберігає питання користувачів про продукти.
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; }
        public AppUser User { get; set; }
        public ICollection<ProductAnswer> ProductAnswers { get; set; }
    }
}
