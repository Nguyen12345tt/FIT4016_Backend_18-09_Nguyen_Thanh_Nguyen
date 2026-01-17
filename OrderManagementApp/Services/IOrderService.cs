using System.Collections.Generic;

namespace OrderManagementApp.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders(string search, int page, int pageSize, out int totalRows);
        Order? GetById(int id);
        string? Create(Order order);
        string? Update(Order order);
        void Delete(int id);
        List<Product> GetProducts();
    }
}