using System;

namespace MethodOverloading
{
    class Program
    {
        // -----------------------------------------------------------
        // 1. PHƯƠNG THỨC PRINT (Overloading)
        // -----------------------------------------------------------

        // Phiên bản 1: Nhận vào số nguyên
        static void Print(int x)
        {
            Console.WriteLine("In so nguyen: " + x);
        }

        // Phiên bản 2: Nhận vào chuỗi
        // Cùng tên "Print" nhưng khác tham số (string thay vì int)
        static void Print(string text)
        {
            Console.WriteLine("In chuoi: " + text);
        }

        // -----------------------------------------------------------
        // 2. PHƯƠNG THỨC ADD (Overloading)
        // -----------------------------------------------------------

        // Phiên bản 1: Cộng 2 số nguyên
        static int Add(int a, int b)
        {
            return a + b;
        }

        // Phiên bản 2: Cộng 2 số thực
        // Cùng tên "Add" nhưng kiểu tham số là double
        static double Add(double a, double b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            // -----------------------------------------------------------
            // GỌI HÀM (C# tự động chọn phiên bản đúng)
            // -----------------------------------------------------------

            // 1. Gọi Print với int -> C# sẽ chọn phiên bản Print(int x)
            Print(100);

            // 2. Gọi Print với string -> C# sẽ chọn phiên bản Print(string text)
            Print("Xin chao C#");

            // 3. Gọi Add(int, int)
            int sumInt = Add(5, 10);
            Console.WriteLine("Tong so nguyen: " + sumInt);

            // 4. Gọi Add(double, double)
            // Lưu ý: 2.5 và 4.5 là số thực, nên C# chọn phiên bản Add(double...)
            double sumDouble = Add(2.5, 4.5);
            Console.WriteLine("Tong so thuc: " + sumDouble);

            Console.ReadKey();
        }
    }
}