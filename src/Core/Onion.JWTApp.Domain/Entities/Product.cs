﻿namespace src.Core.Onion.JwtApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
