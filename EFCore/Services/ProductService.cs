using Microsoft.EntityFrameworkCore;
using EFCore.Models; // Nhớ đổi tên namespace cho đúng
namespace EFCore.Services;
public class ProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context) { _context = context; }

    // CREATE
    public async Task<Product> CreateAsync(Product product)
    {
        // 1. Logic thêm mới
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    // READ ALL (với Include)
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Category) // Tránh N+1
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    // READ BY ID
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    // UPDATE
    public async Task<Product> UpdateAsync(int id, Product updateData)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing == null) throw new Exception("Not found");

        existing.Name = updateData.Name;
        existing.Price = updateData.Price;
        existing.Stock = updateData.Stock;
        existing.CategoryId = updateData.CategoryId;

        await _context.SaveChangesAsync();
        return existing;
    }

    // DELETE (Soft Delete)
    public async Task DeleteAsync(int id)
    {
        var p = await _context.Products.FindAsync(id);
        if (p == null) throw new Exception("Not found");

        // Giả sử có property IsDeleted trong model
        // p.IsDeleted = true; 

        // Nếu xóa cứng:
        _context.Products.Remove(p);
        await _context.SaveChangesAsync();
    }

    // SEARCH & FILTER
    public async Task<List<Product>> SearchAsync(string? searchTerm, int? categoryId)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
            query = query.Where(p => p.Name.Contains(searchTerm));

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId);

        return await query.Include(p => p.Category).ToListAsync();
    }
}