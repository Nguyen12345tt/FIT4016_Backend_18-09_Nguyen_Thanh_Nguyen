using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementApp
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public string Sku { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public int StockQuantity { get; set; }
        [Required] public string Category { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}