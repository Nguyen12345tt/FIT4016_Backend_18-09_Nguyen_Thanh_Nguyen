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
    public ActionResult<List<Category>> GetAll()
    {
        return Ok(_categoryService.GetAllCategories());
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
}
