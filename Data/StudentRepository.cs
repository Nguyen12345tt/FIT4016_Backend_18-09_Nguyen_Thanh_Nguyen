using StudentManagementAPI.Models;

namespace StudentManagementAPI.Data;

/// <summary>
/// In-memory storage for students (for demonstration purposes)
/// </summary>
public class StudentRepository
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    public StudentRepository()
    {
        // Seed with some initial data
        _students.AddRange(new[]
        {
            new Student
            {
                Id = _nextId++,
                FirstName = "Nguyen",
                LastName = "Thanh",
                Email = "nguyen.thanh@student.edu",
                EnrollmentDate = DateTime.Now.AddYears(-2),
                Major = "Computer Science",
                GPA = 3.8
            },
            new Student
            {
                Id = _nextId++,
                FirstName = "Tran",
                LastName = "Van",
                Email = "tran.van@student.edu",
                EnrollmentDate = DateTime.Now.AddYears(-1),
                Major = "Information Technology",
                GPA = 3.5
            },
            new Student
            {
                Id = _nextId++,
                FirstName = "Le",
                LastName = "Thi",
                Email = "le.thi@student.edu",
                EnrollmentDate = DateTime.Now.AddMonths(-6),
                Major = "Software Engineering",
                GPA = 3.9
            }
        });
    }

    /// <summary>
    /// Get all students
    /// </summary>
    public List<Student> GetAll() => _students.ToList();

    /// <summary>
    /// Get student by ID
    /// </summary>
    public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    /// <summary>
    /// Create a new student
    /// </summary>
    public Student Create(Student student)
    {
        student.Id = _nextId++;
        student.EnrollmentDate = DateTime.Now;
        _students.Add(student);
        return student;
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    public Student? Update(int id, Student updatedStudent)
    {
        var student = GetById(id);
        if (student == null) return null;

        student.FirstName = updatedStudent.FirstName;
        student.LastName = updatedStudent.LastName;
        student.Email = updatedStudent.Email;
        student.Major = updatedStudent.Major;
        student.GPA = updatedStudent.GPA;

        return student;
    }

    /// <summary>
    /// Delete a student
    /// </summary>
    public bool Delete(int id)
    {
        var student = GetById(id);
        if (student == null) return false;

        _students.Remove(student);
        return true;
    }

    /// <summary>
    /// Search students by name or email
    /// </summary>
    public List<Student> Search(string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();
        return _students
            .Where(s => 
                s.FirstName.ToLower().Contains(lowerSearchTerm) ||
                s.LastName.ToLower().Contains(lowerSearchTerm) ||
                s.Email.ToLower().Contains(lowerSearchTerm))
            .ToList();
    }
}
