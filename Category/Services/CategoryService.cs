// File: Services/CategoryService.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class CategoryService : ICategoryService
{
    // Dùng static để giữ dữ liệu trong bộ nhớ
    private static List<Category> _categories = new List<Category>
    {
        new Category { Id = 1, Name = "Electronics", Description = "Electronic devices", IsActive = true },
        new Category { Id = 2, Name = "Books", Description = "Books and Magazines", IsActive = true },
        new Category { Id = 3, Name = "Clothing", Description = "Men and Women Clothing", IsActive = true }
    };

    public List<Category> GetAllCategories()
    {
        return _categories;
    }

    public Category? GetCategoryById(int id)
    {
        return _categories.FirstOrDefault(c => c.Id == id);
    }

    public Category CreateCategory(Category category)
    {
        // Tự động tăng ID
        int newId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
        category.Id = newId;
        category.CreatedAt = DateTime.UtcNow;
        _categories.Add(category);
        return category;
    }

    public Category? UpdateCategory(int id, Category updatedCategory)
    {
        var existing = GetCategoryById(id);
        if (existing == null) return null;

        existing.Name = updatedCategory.Name;
        existing.Description = updatedCategory.Description;
        existing.IsActive = updatedCategory.IsActive;

        return existing;
    }

    public bool DeleteCategory(int id)
    {
        var existing = GetCategoryById(id);
        if (existing == null) return false;

        _categories.Remove(existing);
        return true;
    }
}