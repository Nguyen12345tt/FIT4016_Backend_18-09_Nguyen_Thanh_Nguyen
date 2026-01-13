using Microsoft.AspNetCore.Mvc;
using EFCore.Models; // Nhớ đổi tên namespace cho đúng
using EFCore.Services; // Nhớ đổi tên namespace cho đúng

namespace EFCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    // Inject ProductService vào Controller
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product product)
    {
        var createdProduct = await _productService.CreateAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    // PUT: api/products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        try
        {
            var updated = await _productService.UpdateAsync(id, product);
            return Ok(updated);
        }
        catch (Exception) // Bắt lỗi nếu không tìm thấy ID
        {
            return NotFound();
        }
    }

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _productService.DeleteAsync(id);
            return NoContent(); // 204 No Content
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    // API Search (Bài nâng cao)
    [HttpGet("search")]
    public async Task<ActionResult<List<Product>>> Search(string? term, int? catId)
    {
        var results = await _productService.SearchAsync(term, catId);
        return Ok(results);
    }
}