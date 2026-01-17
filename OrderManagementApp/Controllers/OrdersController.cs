using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagementApp.Services;

namespace OrderManagementApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service) { _service = service; }

        public IActionResult Index(string searchString, int? pageNumber)
        {
            int pageSize = 10;
            var items = _service.GetOrders(searchString, pageNumber ?? 1, pageSize, out int total);

            ViewBag.TotalPages = (int)System.Math.Ceiling(total / (double)pageSize);
            ViewBag.CurrentPage = pageNumber ?? 1;
            ViewBag.SearchString = searchString;
            return View(items);
        }

        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_service.GetProducts(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            string? error = _service.Create(order);
            if (error == null) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", error);
            ViewData["ProductId"] = new SelectList(_service.GetProducts(), "Id", "Name", order.ProductId);
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _service.GetById(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.Id) return NotFound();

            string? error = _service.Update(order);
            if (error == null) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", error);
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _service.GetById(id);
            return order == null ? NotFound() : View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}