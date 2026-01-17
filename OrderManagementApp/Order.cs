using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementApp
{
    public class Order
    {
        [Key] public int Id { get; set; }

        [Required] public int ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product? Product { get; set; }

        [Required]
        [RegularExpression(@"^ORD-\d{8}-\d{4}$", ErrorMessage = "Format: ORD-YYYYMMDD-XXXX")]
        public string? OrderNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string? CustomerEmail { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required] public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}