using System;

namespace ArrayMethods
{
    class Program
    {
        // -----------------------------------------------------------
        // 1. PHƯƠNG THỨC TÍNH TỔNG
        // -----------------------------------------------------------
        static int SumArray(int[] numbers)
        {
            int total = 0; // Biến tích lũy

            // Dùng foreach để duyệt qua từng số trong mảng
            foreach (int number in numbers)
            {
                total += number; // Cộng dồn vào total
            }

            return total;
        }

        // -----------------------------------------------------------
        // 2. PHƯƠNG THỨC TÌM SỐ LỚN NHẤT
        // -----------------------------------------------------------
        static int FindMax(int[] numbers)
        {
            // Mẹo: Luôn gán max bằng phần tử đầu tiên của mảng.
            // Đừng gán bằng 0, vì nếu mảng toàn số âm thì 0 sẽ sai.
            int max = numbers[0];

            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number; // Cập nhật kỷ lục mới
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            int[] scores = { 85, 92, 78, 90, 88 };

            // -----------------------------------------------------------
            // GỌI HÀM VÀ IN KẾT QUẢ
            // -----------------------------------------------------------

            // Gọi SumArray
            int totalScore = SumArray(scores);
            Console.WriteLine("Tong diem la: " + totalScore);

            // Gọi FindMax
            int highestScore = FindMax(scores);
            Console.WriteLine("Diem cao nhat la: " + highestScore);

            Console.ReadKey();
        }
    }
}