using System;
using System.Text; // Thêm thư viện này để dùng Encoding

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- SỬA LỖI FONT CHỮ ---
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Chào mừng đến với trò chơi đoán số!");

            int secretNumber = 50;
            int guess = 0;

            Console.WriteLine("Hãy đoán một số từ 1 đến 100:");

            // --- SỬA LỖI VÒNG LẶP ---
            // Điều kiện: Chừng nào đoán sai thì còn lặp lại
            while (guess != secretNumber)
            {
                // BƯỚC QUAN TRỌNG: Phải cho người dùng nhập số ở đây!
                Console.Write("Nhập số bạn đoán: ");
                string input = Console.ReadLine();

                // Chuyển đổi chuỗi nhập vào thành số nguyên
                // (Để đơn giản mình dùng int.Parse, thực tế nên dùng TryParse để tránh lỗi)
                if (int.TryParse(input, out guess) == false)
                {
                    Console.WriteLine("Vui lòng nhập một số hợp lệ!");
                    continue; // Bỏ qua lần lặp này nếu nhập sai định dạng
                }

                // Kiểm tra logic
                if (guess < secretNumber)
                {
                    Console.WriteLine("Quá thấp");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Quá cao");
                }
                else
                {
                    Console.WriteLine("Chính xác! Chúc mừng bạn.");
                }
            }
            // Kết thúc vòng lặp
        }
    }
}