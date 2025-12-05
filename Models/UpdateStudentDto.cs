namespace StudentManagementAPI.Models;

/// <summary>
/// Data Transfer Object for updating an existing student
/// </summary>
public class UpdateStudentDto
{
    /// <summary>
    /// Student's first name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Student's last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Student's email address
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Student's major/course
    /// </summary>
    public string? Major { get; set; }

    /// <summary>
    /// Student's GPA (Grade Point Average)
    /// </summary>
    public double? GPA { get; set; }
}
