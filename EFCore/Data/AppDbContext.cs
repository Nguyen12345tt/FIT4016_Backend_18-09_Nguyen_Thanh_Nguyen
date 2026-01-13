using Microsoft.EntityFrameworkCore;
using EFCore.Models; // 👉 LƯU Ý: Đổi 'EFCore' thành tên Namespace project của bạn nếu khác

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Các DbSet
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 👇 ĐOẠN CODE FLUENT API BẮT ĐẦU TỪ ĐÂY [cite: 263-283] 👇

        modelBuilder.Entity<Product>(entity =>
        {
            // 1. Đặt tên bảng trong SQL
            entity.ToTable("Products");

            // 2. Cấu hình Khóa chính
            entity.HasKey(p => p.Id);

            // 3. Cấu hình các cột (Properties)
            entity.Property(p => p.Name)
                  .IsRequired()       // Bắt buộc (Not Null)
                  .HasMaxLength(200); // Độ dài tối đa 200

            entity.Property(p => p.Price)
                  .HasColumnType("decimal(18,2)"); // Định dạng tiền tệ

            // 4. Cấu hình Mối quan hệ (Relationship)
            entity.HasOne(p => p.Category)          // Một Product có 1 Category
                  .WithMany(c => c.Products)        // Một Category có nhiều Products
                  .HasForeignKey(p => p.CategoryId) // Khóa ngoại là CategoryId
                  .OnDelete(DeleteBehavior.Cascade); // Xóa Category -> Xóa luôn Product
        });

        // 👆 KẾT THÚC ĐOẠN CODE FLUENT API 👆
    }
}