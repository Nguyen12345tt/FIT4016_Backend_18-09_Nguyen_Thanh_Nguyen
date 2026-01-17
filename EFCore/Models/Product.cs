using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Cần thiết cho [Column], [ForeignKey]

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    // Chỉ định kiểu dữ liệu tiền tệ trong SQL
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    // Validate giá trị số nguyên phải nằm trong khoảng 0 - 10000
    [Range(0, 10000)]
    public int Stock { get; set; }

    // Các properties bổ sung theo yêu cầu
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    // Chỉ định Foreign Key rõ ràng
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}