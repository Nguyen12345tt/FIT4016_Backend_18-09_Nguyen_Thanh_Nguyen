using System;

namespace Constructor
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;

        // Constructor nhận tham số
        public Product(int id, string name, double price)
        {
            ProductId = id;
            ProductName = name;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Sản phẩm: {ProductName} (ID: {ProductId}) - Giá: {Price}$");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--- TODO 5.2: CONSTRUCTOR ---");

            // Tạo đối tượng dùng Constructor (nhanh gọn hơn cách gán từng dòng)
            Product p1 = new Product(101, "Laptop Dell", 1500);
            Product p2 = new Product(102, "Mouse Logitech", 25);

            p1.DisplayInfo();
            p2.DisplayInfo();
        }
    }
}