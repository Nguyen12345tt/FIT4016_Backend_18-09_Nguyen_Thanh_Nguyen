using System;
using System.Text;
namespace BasicMethods
{
    class Program
    {
        // TODO: Viết phương thức tính tổng 2 số

        // Tên: Add
        static int Add(int a, int b)
        // Tham số: int a, int b
        {
            int sum = a + b;
            return sum;
        }
        // Trả về: int

        // TODO: Viết phương thức tính tích 2 số

        // Tên: Multiply
        static double Multiply(double a, double b)
        // Tham số: double x, double y
        {
            double product = a * b;
            return product;
        }
        // Trả về: double

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // TODO: Gọi phương thức Add và in kết quả
            int ketQuaTong = Add(10, 6);
            Console.WriteLine("Kết quả tổng:" + ketQuaTong);

            // TODO: Gọi phương thức Multiply và in kết quả
            double ketQuaTich = Multiply(12, 6);
            Console.WriteLine("Kết quả tích:" + ketQuaTich);
        }
    }
}
