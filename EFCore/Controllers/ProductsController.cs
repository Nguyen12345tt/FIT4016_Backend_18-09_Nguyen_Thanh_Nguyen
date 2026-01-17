using Microsoft.AspNetCore.Mvc;
using EFCore.Models; // Thay bằng namespace chứa Product của bạn
using EFCore.Services; // Thay bằng namespace chứa ProductService của bạn

namespace EFCore.Controllers
{
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

        // 1. GET: api/products (Lấy danh sách)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync(); // [cite: 195]
            return Ok(products);
        }

        // 2. GET: api/products/{id} (Lấy chi tiết)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id); // [cite: 203]
            if (product == null) return NotFound();
            return Ok(product);
        }

        // 3. POST: api/products (Thêm mới)
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var createdProduct = await _productService.CreateAsync(product); // [cite: 187]
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        // 4. PUT: api/products/{id} (Cập nhật)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            try
            {
                var updatedProduct = await _productService.UpdateAsync(id, product); // [cite: 210]
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // 5. DELETE: api/products/{id} (Xóa)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id); // [cite: 222]
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // 6. GET: api/products/search?term=abc (Tìm kiếm - Optional)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? term, [FromQuery] int? categoryId)
        {
            var result = await _productService.SearchAsync(term, categoryId); // [cite: 233]
            return Ok(result);
        }
    }
}