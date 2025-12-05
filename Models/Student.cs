namespace StudentManagementAPI.Models;

/// <summary>
/// Represents a student in the system
/// </summary>
public class Student
{
    /// <summary>
    /// Unique identifier for the student
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Student's first name
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Student's last name
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Student's email address
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Student's enrollment date
    /// </summary>
    public DateTime EnrollmentDate { get; set; }

    /// <summary>
    /// Student's major/course
    /// </summary>
    public string? Major { get; set; }

    /// <summary>
    /// Student's GPA (Grade Point Average)
    /// </summary>
    public double? GPA { get; set; }
}
