using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers;

/// <summary>
/// API controller for managing students
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly ILogger<StudentsController> _logger;

    public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    /// <summary>
    /// Get all students
    /// </summary>
    /// <returns>List of all students</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Student>> GetAllStudents()
    {
        _logger.LogInformation("Getting all students");
        var students = _studentService.GetAllStudents();
        return Ok(students);
    }

    /// <summary>
    /// Get a specific student by ID
    /// </summary>
    /// <param name="id">The student ID</param>
    /// <returns>The student with the specified ID</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Student> GetStudentById(int id)
    {
        _logger.LogInformation("Getting student with ID: {Id}", id);
        var student = _studentService.GetStudentById(id);
        
        if (student == null)
        {
            _logger.LogWarning("Student with ID {Id} not found", id);
            return NotFound(new { message = $"Student with ID {id} not found" });
        }

        return Ok(student);
    }

    /// <summary>
    /// Create a new student
    /// </summary>
    /// <param name="studentDto">The student data</param>
    /// <returns>The created student</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Student> CreateStudent([FromBody] CreateStudentDto studentDto)
    {
        try
        {
            _logger.LogInformation("Creating new student: {Email}", studentDto.Email);
            var student = _studentService.CreateStudent(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Validation error creating student");
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    /// <param name="id">The student ID</param>
    /// <param name="studentDto">The updated student data</param>
    /// <returns>The updated student</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Student> UpdateStudent(int id, [FromBody] UpdateStudentDto studentDto)
    {
        try
        {
            _logger.LogInformation("Updating student with ID: {Id}", id);
            var student = _studentService.UpdateStudent(id, studentDto);
            
            if (student == null)
            {
                _logger.LogWarning("Student with ID {Id} not found for update", id);
                return NotFound(new { message = $"Student with ID {id} not found" });
            }

            return Ok(student);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Validation error updating student {Id}", id);
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Delete a student
    /// </summary>
    /// <param name="id">The student ID</param>
    /// <returns>No content on success</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteStudent(int id)
    {
        _logger.LogInformation("Deleting student with ID: {Id}", id);
        var result = _studentService.DeleteStudent(id);
        
        if (!result)
        {
            _logger.LogWarning("Student with ID {Id} not found for deletion", id);
            return NotFound(new { message = $"Student with ID {id} not found" });
        }

        return NoContent();
    }

    /// <summary>
    /// Search students by name or email
    /// </summary>
    /// <param name="searchTerm">The search term</param>
    /// <returns>List of matching students</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Student>> SearchStudents([FromQuery] string searchTerm)
    {
        _logger.LogInformation("Searching students with term: {SearchTerm}", searchTerm);
        var students = _studentService.SearchStudents(searchTerm);
        return Ok(students);
    }
}
