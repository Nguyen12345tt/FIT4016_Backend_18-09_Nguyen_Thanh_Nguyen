using System;

namespace Recursion
{
    class Program
    {
        // -----------------------------------------------------------
        // PHƯƠNG THỨC TÍNH GIAI THỪA (ĐỆ QUY)
        // -----------------------------------------------------------
        // Tên: Factorial
        // Tham số: int n
        // Trả về: long (Vì giai thừa tăng rất nhanh, int sẽ bị tràn số sớm)
        static long Factorial(int n)
        {
            // 1. Điều kiện dừng (Base case)
            // Nếu không có cái này, hàm sẽ chạy mãi mãi -> Lỗi StackOverflow
            if (n == 0)
            {
                return 1; // Vì 0! = 1
            }

            // 2. Bước đệ quy (Recursive step)
            // n! = n * (n-1)!
            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            // -----------------------------------------------------------
            // GỌI HÀM VÀ IN KẾT QUẢ
            // -----------------------------------------------------------

            // Tính 5! = 120
            long ketQua5 = Factorial(5);
            Console.WriteLine("5! = " + ketQua5);

            // Tính 10! = 3,628,800
            long ketQua10 = Factorial(10);
            Console.WriteLine("10! = " + ketQua10);

            Console.ReadKey();
        }
    }
}