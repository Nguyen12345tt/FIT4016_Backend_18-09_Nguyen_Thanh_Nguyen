using Microsoft.AspNetCore.Mvc;
using EFCore.Models;
using EFCore.Services;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _categoryService.GetAllAsync();
            return Ok(list);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                var created = await _categoryService.CreateAsync(category);
                return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}