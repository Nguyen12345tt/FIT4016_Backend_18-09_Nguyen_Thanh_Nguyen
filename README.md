# Student Management API - C# Backend Exercise

A RESTful API built with ASP.NET Core for managing student records. This project demonstrates backend development concepts including:
- RESTful API design
- CRUD operations
- Service layer architecture
- Dependency injection
- Input validation
- Error handling
- Logging

## Features

- **GET /api/students** - Get all students
- **GET /api/students/{id}** - Get a specific student by ID
- **POST /api/students** - Create a new student
- **PUT /api/students/{id}** - Update an existing student
- **DELETE /api/students/{id}** - Delete a student
- **GET /api/students/search?searchTerm={term}** - Search students by name or email

## Project Structure

```
StudentManagementAPI/
├── Controllers/          # API Controllers
│   └── StudentsController.cs
├── Models/              # Data models and DTOs
│   ├── Student.cs
│   ├── CreateStudentDto.cs
│   └── UpdateStudentDto.cs
├── Services/            # Business logic layer
│   ├── IStudentService.cs
│   └── StudentService.cs
├── Data/                # Data access layer
│   └── StudentRepository.cs
├── Program.cs           # Application entry point
└── appsettings.json     # Configuration
```

## Prerequisites

- .NET 10.0 SDK or later
- Any IDE or text editor (Visual Studio, VS Code, Rider, etc.)

## Getting Started

### 1. Clone the repository
```bash
git clone <repository-url>
cd FIT4016_Backend_18-09_Nguyen_Thanh_Nguyen
```

### 2. Build the project
```bash
dotnet build
```

### 3. Run the application
```bash
dotnet run
```

The API will start and listen on:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

### 4. Access the API
Open your browser or API client (Postman, curl, etc.) and navigate to:
- OpenAPI documentation: `https://localhost:5001/openapi/v1.json`

## API Examples

### Get All Students
```bash
curl -X GET https://localhost:5001/api/students
```

### Get Student by ID
```bash
curl -X GET https://localhost:5001/api/students/1
```

### Create a New Student
```bash
curl -X POST https://localhost:5001/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@student.edu",
    "major": "Computer Science",
    "gpa": 3.7
  }'
```

### Update a Student
```bash
curl -X PUT https://localhost:5001/api/students/1 \
  -H "Content-Type: application/json" \
  -d '{
    "gpa": 3.9
  }'
```

### Delete a Student
```bash
curl -X DELETE https://localhost:5001/api/students/1
```

### Search Students
```bash
curl -X GET "https://localhost:5001/api/students/search?searchTerm=nguyen"
```

## Student Model

```json
{
  "id": 1,
  "firstName": "Nguyen",
  "lastName": "Thanh",
  "email": "nguyen.thanh@student.edu",
  "enrollmentDate": "2023-09-18T00:00:00",
  "major": "Computer Science",
  "gpa": 3.8
}
```

## Validation Rules

- **FirstName**: Required
- **LastName**: Required
- **Email**: Required, must be valid email format
- **GPA**: Optional, must be between 0.0 and 4.0
- **Major**: Optional

## Technologies Used

- **ASP.NET Core 10.0** - Web framework
- **C# 13** - Programming language
- **OpenAPI** - API documentation
- **In-memory storage** - Data persistence (for demonstration)

## Architecture

The project follows a clean architecture pattern with separation of concerns:

1. **Controllers**: Handle HTTP requests and responses
2. **Services**: Contain business logic and validation
3. **Data**: Manage data access and storage
4. **Models**: Define data structures and DTOs

## Development Notes

- This project uses in-memory storage for simplicity. In production, you would integrate with a real database (SQL Server, PostgreSQL, etc.)
- CORS is enabled for all origins in development mode
- Logging is configured to capture important application events
- The API uses DTOs (Data Transfer Objects) to separate internal models from API contracts

## Future Enhancements

- Add database integration (Entity Framework Core)
- Implement authentication and authorization
- Add pagination for student lists
- Implement unit and integration tests
- Add Swagger UI for interactive API documentation
- Implement data validation attributes
- Add more complex search and filtering capabilities

## License

This project is for educational purposes.
