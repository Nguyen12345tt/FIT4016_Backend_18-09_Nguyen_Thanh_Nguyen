using System;
using System.Text; // Hỗ trợ tiếng Việt

namespace BasicClass
{
    // Lớp Student
    class Student
    {
        // Thuộc tính
        public string StudentId;
        public string Name;
        public double GPA;

        // Phương thức Display
        public void Display()
        {
            Console.WriteLine($"ID:{StudentId} | Tên: {Name} | GPA: {GPA} ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----5.1-----");
            Console.OutputEncoding = Encoding.UTF8;
            
            // (Ví dụ tạo 3 sinh viên)
            // Tạo đối tượng sinh viên 1
            Student sv1 = new Student();
            sv1.StudentId = "123";
            sv1.Name = "Hoàng Quốc Triệu";
            sv1.GPA = 3.0;

            Student sv2 = new Student();
            sv2.StudentId = "1234";
            sv2.Name = "Đặng Khánh Toàn";
            sv2.GPA = 3.0;

            Student sv3 = new Student();
            sv3.StudentId = "654";
            sv3.Name = "Nguyễn Thành Nguyên";
            sv3.GPA = 7.0;

            // Gọi phương thức Display
            sv1.Display();
            sv2.Display();
            sv3.Display();
        }
    }
    
}