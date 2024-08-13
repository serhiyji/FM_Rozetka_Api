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
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ProductAnswer> ProductAnswers { get; set; }
    }
}
