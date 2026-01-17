using Microsoft.EntityFrameworkCore;
using EFCore.Models;

namespace EFCore.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách (để xem ID sau khi tạo)
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        // Tạo mới
        public async Task<Category> CreateAsync(Category category)
        {
            // Gán ngày tạo mặc định nếu chưa có
            if (category.CreatedAt == default)
                category.CreatedAt = DateTime.UtcNow;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}