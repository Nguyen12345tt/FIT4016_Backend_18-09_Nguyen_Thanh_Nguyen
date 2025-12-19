using System;
using System.Text;
namespace ForeachExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Tạo mảng tên các bạn
            Console.OutputEncoding = Encoding.UTF8;
            string[] friends = { "Mai", "Bình", "Chi", "Danh" };

            // TODO: In danh sách bạn bè
            foreach (var item in friends)
            {
                Console.WriteLine($"{Array.IndexOf(friends, item) + 1}. {item}");
            }
            // Gợi ý: Dùng foreach


        }

    }

}
