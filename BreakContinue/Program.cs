using System;

namespace BreakContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: In các số lẻ từ 1 đến 20 (dùng continue)
            int i;
            for (i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                Console.Write(i + " ");
            }
            // Output: 1 3 5 7 9 11 13 15 17 19

            // TODO: Tìm số 7 trong mảng [2, 5, 7, 1, 9, 7, 3]
            int[] numbers = { 2, 5, 7, 1, 9, 7, 3 };
            for (i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 7)
                {
                    Console.WriteLine($"\nTìm thấy số 7 tại vị trí {i}");
                    break;
                }
            }
            // Khi tìm thấy, in "Tìm thấy số 7 tại vị trí [chỉ số]" rồi dừng (break)
        }
    }
}
