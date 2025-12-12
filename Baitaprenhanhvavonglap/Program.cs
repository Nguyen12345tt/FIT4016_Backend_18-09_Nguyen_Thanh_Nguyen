using System;
using System.Text; // Để gõ tiếng Việt không lỗi font

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8; // Hỗ trợ tiếng Việt
        Console.WriteLine("=== Chương trình Xếp loại Sinh viên ===\n");

        // TODO 1 & 2: Đã có trong đề bài
        string hoVaTen = "Nguyễn Thành Nguyên";
        double diem = 7.5;
        Console.WriteLine($"Họ tên: {hoVaTen}");
        Console.WriteLine($"Điểm: {diem}");

        // TODO 3: Xếp loại (Điền vào chỗ trống)
        string xepLoai = "";
        if (diem >= 8.5)
        {
            xepLoai = "Giỏi";
        }
        else if (diem >= 7.0)
        {
            xepLoai = "Khá";
        }
        else if (diem >= 5.5)
        {
            xepLoai = "Trung bình";
        }
        else
        {
            xepLoai = "Yếu";
        }
        Console.WriteLine($"Xếp loại: {xepLoai}\n");

        // ---------------------------------------------------------

        // TODO 4: Vòng lặp for
        string[] tenSV = { "Nguyễn Văn A", "Trần Thị B", "Lê Văn C" };
        double[] diemSV = { 8.5, 7.2, 5.8 };

        Console.WriteLine("\n=== Bảng Điểm ===");
        for (int i = 0; i < tenSV.Length; i++)
        {
            // TODO 5: In ra tên, điểm và xếp loại
            string xl = "";
            if (diemSV[i] >= 8.5) xl = "Giỏi";
            else if (diemSV[i] >= 7.0) xl = "Khá";
            else if (diemSV[i] >= 5.5) xl = "TB";
            else xl = "Yếu";

            Console.WriteLine($"SV: {tenSV[i]} - Điểm: {diemSV[i]} - Xếp loại: {xl}");
        }

        // TODO 6: Dùng while loop tính tổng
        double tongDiem = 0;
        int j = 0;

        while (j < diemSV.Length)
        {
            tongDiem += diemSV[j]; // Cộng dồn điểm
            j++;
        }

        Console.WriteLine($"\nTổng điểm: {tongDiem}");
        Console.WriteLine($"Điểm trung bình: {(tongDiem / diemSV.Length):F2}");
    }
}