// File: Controllers/CategoriesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    // Constructor Injection
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // 1. GET /api/categories
    [HttpGet]
    // GET /api/categories?name=electronics

    public ActionResult<List<Category>> GetAllCategories(string? name = null)
    {
        var categories = _categoryService.GetAllCategories();
        if (!string.IsNullOrEmpty(name))
        {
            // TODO: Hãy viết LINQ để filter theo name (case-insensitive)
            categories = categories.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                                   .ToList();
        }
        return Ok(categories);
    }

    // 2. GET /api/categories/{id}
    [HttpGet("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    // 3. POST /api/categories
    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        var created = _categoryService.CreateCategory(category);
        // Trả về 201 Created và Header Location trỏ về API lấy chi tiết
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // 4. PUT /api/categories/{id}
    [HttpPut("{id}")]
    public ActionResult Update(int id, Category category)
    {
        var updated = _categoryService.UpdateCategory(id, category);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    // 5. DELETE /api/categories/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _categoryService.DeleteCategory(id);
        if (!result) return NotFound();
        return NoContent(); // 204
    }

    [HttpGet("paging")] // Đặt route khác hoặc sửa route cũ
    public ActionResult<List<Category>> GetAllCategoriesPaging(int page = 1, int pageSize = 10)
    {
        var categories = _categoryService.GetAllCategories();

        // Công thức Pagination
        var paginated = categories.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

        return Ok(paginated);
    }
}