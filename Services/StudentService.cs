using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services;

/// <summary>
/// Service layer for student business logic
/// </summary>
public class StudentService : IStudentService
{
    private readonly StudentRepository _repository;

    public StudentService(StudentRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get all students
    /// </summary>
    public List<Student> GetAllStudents()
    {
        return _repository.GetAll();
    }

    /// <summary>
    /// Get student by ID
    /// </summary>
    public Student? GetStudentById(int id)
    {
        return _repository.GetById(id);
    }

    /// <summary>
    /// Create a new student
    /// </summary>
    public Student CreateStudent(CreateStudentDto studentDto)
    {
        // Validate GPA range
        if (studentDto.GPA.HasValue && (studentDto.GPA < 0 || studentDto.GPA > 4.0))
        {
            throw new ArgumentException("GPA must be between 0 and 4.0");
        }

        // Validate email format (basic validation)
        if (!IsValidEmail(studentDto.Email))
        {
            throw new ArgumentException("Invalid email format");
        }

        var student = new Student
        {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Email = studentDto.Email,
            Major = studentDto.Major,
            GPA = studentDto.GPA
        };

        return _repository.Create(student);
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    public Student? UpdateStudent(int id, UpdateStudentDto studentDto)
    {
        var existingStudent = _repository.GetById(id);
        if (existingStudent == null)
        {
            return null;
        }

        // Validate GPA if provided
        if (studentDto.GPA.HasValue && (studentDto.GPA < 0 || studentDto.GPA > 4.0))
        {
            throw new ArgumentException("GPA must be between 0 and 4.0");
        }

        // Validate email if provided
        if (studentDto.Email != null && !IsValidEmail(studentDto.Email))
        {
            throw new ArgumentException("Invalid email format");
        }

        // Update only provided fields
        var updatedStudent = new Student
        {
            Id = existingStudent.Id,
            FirstName = studentDto.FirstName ?? existingStudent.FirstName,
            LastName = studentDto.LastName ?? existingStudent.LastName,
            Email = studentDto.Email ?? existingStudent.Email,
            Major = studentDto.Major ?? existingStudent.Major,
            GPA = studentDto.GPA ?? existingStudent.GPA,
            EnrollmentDate = existingStudent.EnrollmentDate
        };

        return _repository.Update(id, updatedStudent);
    }

    /// <summary>
    /// Delete a student
    /// </summary>
    public bool DeleteStudent(int id)
    {
        return _repository.Delete(id);
    }

    /// <summary>
    /// Search students by name or email
    /// </summary>
    public List<Student> SearchStudents(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return GetAllStudents();
        }

        return _repository.Search(searchTerm);
    }

    /// <summary>
    /// Basic email validation
    /// </summary>
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
