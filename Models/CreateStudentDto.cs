namespace StudentManagementAPI.Models;

/// <summary>
/// Data Transfer Object for creating a new student
/// </summary>
public class CreateStudentDto
{
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
    /// Student's major/course
    /// </summary>
    public string? Major { get; set; }

    /// <summary>
    /// Student's GPA (Grade Point Average)
    /// </summary>
    public double? GPA { get; set; }
}
