using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        public OrderService(OrderDbContext context) { _context = context; }

        public List<Order> GetOrders(string search, int page, int pageSize, out int totalRows)
        {
            var query = _context.Orders.Include(o => o.Product).AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(o =>
                    (o.OrderNumber != null && o.OrderNumber.Contains(search)) ||
                    (o.CustomerName != null && o.CustomerName.Contains(search)));

            totalRows = query.Count();
            return query.OrderByDescending(o => o.CreatedAt)
                        .Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Order? GetById(int id) =>
            _context.Orders.Include(o => o.Product).AsNoTracking().FirstOrDefault(o => o.Id == id);

        public string? Create(Order order)
        {
            var prod = _context.Products.Find(order.ProductId);
            if (prod == null) return "Product not found.";
            if (order.Quantity > prod.StockQuantity) return "Quantity exceeds stock.";
            if (order.OrderDate > DateTime.Now) return "Order date cannot be in future.";
            if (order.DeliveryDate < order.OrderDate) return "Delivery date invalid.";

            try { _context.Orders.Add(order); _context.SaveChanges(); return null; }
            catch (Exception ex) { return ex.Message; }
        }

        public string? Update(Order order)
        {
            var old = _context.Orders.Find(order.Id);
            if (old == null) return "Not found.";

            if (order.DeliveryDate < old.OrderDate) return "Delivery date invalid.";

            // Chỉ update các trường cho phép [cite: 47-48]
            old.CustomerName = order.CustomerName;
            old.CustomerEmail = order.CustomerEmail;
            old.Quantity = order.Quantity;
            old.DeliveryDate = order.DeliveryDate;
            old.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return null;
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null) { _context.Orders.Remove(order); _context.SaveChanges(); }
        }

        public List<Product> GetProducts() => _context.Products.ToList();
    }
}