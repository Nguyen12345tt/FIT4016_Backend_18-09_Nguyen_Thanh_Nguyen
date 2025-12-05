using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services;

/// <summary>
/// Interface for student service operations
/// </summary>
public interface IStudentService
{
    List<Student> GetAllStudents();
    Student? GetStudentById(int id);
    Student CreateStudent(CreateStudentDto studentDto);
    Student? UpdateStudent(int id, UpdateStudentDto studentDto);
    bool DeleteStudent(int id);
    List<Student> SearchStudents(string searchTerm);
}
