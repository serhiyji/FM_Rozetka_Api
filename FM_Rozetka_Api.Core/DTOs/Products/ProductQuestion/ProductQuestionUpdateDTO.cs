﻿
namespace FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion
{
    public class ProductQuestionUpdateDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool OpenQuestion { get; set; }
        public bool hasAnswer { get; set; } 
    }
}
