using System.ComponentModel.DataAnnotations; // Bắt buộc

public class Category
{
    [Key]  // Chỉ định Primary Key
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên danh mục là bắt buộc")] // Bắt buộc không null
    [MaxLength(100)] // Giới hạn độ dài 100 ký tự
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; } // Optional

    // Thêm Property mới theo yêu cầu
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Property
    public ICollection<Product> Products { get; set; } = new List<Product>();
}