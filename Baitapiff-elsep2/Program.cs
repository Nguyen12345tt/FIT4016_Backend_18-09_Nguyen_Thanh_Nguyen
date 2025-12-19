using System;
using System.Text;
namespace GradeClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // TODO: Nhập điểm (giả sử: 75)

            int score = 90; // Thay đổi giá trị để test khác

            // TODO: Phân loại điểm

            // 90-100: A (Xuất sắc)

            // 80-89: B (Khá)

            // 70-79: C (Trung bình)

            // 60-69: D (Yếu)

            // < 60: F (Không đạt)
            if (score >= 90 && score <= 100)
            {
                Console.WriteLine("Grade: A (Xuất sắc)");
            }
            else if (score >= 80 && score < 90)
            {
                Console.WriteLine("Grade: B (Khá)");
            }
            else if (score >= 70 && score < 80)
            {
                Console.WriteLine("Grade: C (Trung bình)");
            }
            else if (score >= 60 && score < 70)
            {
                Console.WriteLine("Grade: D (Yếu)");
            }
            else if (score < 60)
            {
                Console.WriteLine("Grade: F (Không đạt)");
            }
            else
            {
                Console.WriteLine("Invalid score");
            }
            // TODO: In kết quả

        }

    }

}
