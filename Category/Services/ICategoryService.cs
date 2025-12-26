// File: Services/ICategoryService.cs
using System.Collections.Generic;

public interface ICategoryService
{
    List<Category> GetAllCategories();
    Category? GetCategoryById(int id);
    Category CreateCategory(Category category);
    Category? UpdateCategory(int id, Category category);
    bool DeleteCategory(int id);
}