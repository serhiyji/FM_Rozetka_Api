﻿
namespace FM_Rozetka_Api.Core.DTOs.OrderItem
{
    public class OrderItemUpdateDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
