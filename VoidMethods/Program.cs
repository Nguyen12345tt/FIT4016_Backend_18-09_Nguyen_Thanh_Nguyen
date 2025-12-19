using System;
using System.Text;

namespace VoidMethods
{
    class Program
    {
        // -----------------------------------------------------------
        // PHƯƠNG THỨC IN HỘP (Đã sửa)
        // -----------------------------------------------------------
        // Tên: PrintBox
        // Tham số: string text (Đã thêm vào đây)
        // Trả về: void (Không return, chỉ in ra màn hình)
        static void PrintBox(string text)
        {
            // Bước 1: Tạo đường viền trên và dưới
            // Độ dài viền = độ dài chữ + 4 (2 dấu * và 2 khoảng trắng 2 bên)
            string border = new string('*', text.Length + 4);

            // Bước 2: In ra màn hình
            Console.WriteLine(border);          // Viền trên
            Console.WriteLine("* " + text + " *"); // Nội dung ở giữa
            Console.WriteLine(border);          // Viền dưới
        }

        static void Main(string[] args)
        {
            // -----------------------------------------------------------
            // GỌI PHƯƠNG THỨC
            // -----------------------------------------------------------

            Console.WriteLine("--- Hop thu 1 ---");
            PrintBox("Hello");

            Console.WriteLine("\n--- Hop thu 2 ---");
            PrintBox("C# is fun!");

            Console.WriteLine("\n--- Hop thu 3 ---");
            PrintBox("Void method = Khong return");

            // Dừng màn hình để xem
            Console.ReadKey();
        }
    }
}