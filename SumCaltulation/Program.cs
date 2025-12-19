using System;
using System.Text;
namespace SumCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // TODO: Tính tổng các số từ 1 đến 100
            int i;
            int sum = 0;
            for (i = 1; i <= 100; i++)
            {
                sum += i;
            }
             Console.WriteLine("Tổng các số từ 1 đến 100: " + sum);
        }

    }

}
