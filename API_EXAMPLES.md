# API Testing Examples

This file contains example requests for testing the Student Management API.

## Get All Students
```bash
curl -X GET http://localhost:5000/api/students
```

## Get Student by ID
```bash
curl -X GET http://localhost:5000/api/students/1
```

## Create New Student
```bash
curl -X POST http://localhost:5000/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@student.edu",
    "major": "Computer Science",
    "gpa": 3.7
  }'
```

## Update Student
```bash
curl -X PUT http://localhost:5000/api/students/1 \
  -H "Content-Type: application/json" \
  -d '{
    "gpa": 3.9,
    "major": "Software Engineering"
  }'
```

## Delete Student
```bash
curl -X DELETE http://localhost:5000/api/students/1
```

## Search Students
```bash
curl -X GET "http://localhost:5000/api/students/search?searchTerm=nguyen"
```

## Test Invalid Email (Should return 400 Bad Request)
```bash
curl -X POST http://localhost:5000/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Test",
    "lastName": "Invalid",
    "email": "not-an-email",
    "major": "Testing"
  }'
```

## Test Invalid GPA (Should return 400 Bad Request)
```bash
curl -X POST http://localhost:5000/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Test",
    "lastName": "Invalid",
    "email": "test@example.com",
    "gpa": 5.0
  }'
```

## Test Get Non-existent Student (Should return 404 Not Found)
```bash
curl -X GET http://localhost:5000/api/students/999
```
