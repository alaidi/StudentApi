# Student API Project Setup Guide

## Prerequisites
- .NET 9.0 SDK
- An IDE (Visual Studio, VS Code, or Rider)

## Project Creation and Setup

1. Create a new ASP.NET Core Web API project:
```bash
dotnet new webapi -n StudentApi
cd StudentApi
```

2. Add required NuGet packages:
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.2
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 9.0.2
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.2
dotnet add package Scalar.AspNetCore --version 2.0.29
```

## Project Structure

Create the following folders and files:

```
StudentApi/
├── Controllers/
│   └── StudentsController.cs
├── Models/
│   ├── Student.cs
│   ├── Gender.cs
│   └── PaginatedList.cs
├── Data/
│   ├── SchoolContext.cs
│   └── DbSeeder.cs
└── Program.cs
```

## Implementation Steps

1. Define the Student Model:
- Create Gender enum
- Create Student class with properties:
  - Id
  - Name
  - BirthDate
  - Phone
  - Gender

2. Create DbContext:
- Implement SchoolContext class
- Configure entity relationships
- Add DbSet for Students

3. Configure Program.cs:
- Add Entity Framework services
- Configure in-memory database
- Add controllers and OpenAPI support
- Set up HTTPS redirection
- Configure database seeding

4. Implement StudentsController:
- CRUD operations (Create, Read, Update, Delete)
- Pagination support
- Search functionality with filters

5. Add Database Seeding:
- Create DbSeeder class
- Add sample data for testing

## API Endpoints

The API provides the following endpoints:

- GET /api/students - Get all students (paginated)
- GET /api/students/{id} - Get student by ID
- POST /api/students - Create new student
- PUT /api/students/{id} - Update existing student
- DELETE /api/students/{id} - Delete student
- GET /api/students/search - Search students with filters

## Testing

1. Run the application:
```bash
dotnet run
```

2. Access the API:
- HTTP: http://localhost:5014
- HTTPS: https://localhost:7014

3. Test endpoints using:
- Swagger UI (in Development)
- HTTP client like Postman
- The provided StudentApi.http file

## Sample Request

Creating a new student:
```http
POST http://localhost:5014/api/students
Content-Type: application/json

{
    "name": "سارة الخالدي",
    "birthDate": "2001-06-15T00:00:00",
    "phone": "+966512345678",
    "gender": "Female"
}
```

## Notes
- The application uses an in-memory database for development
- All dates are stored in UTC
- Phone numbers should follow international format
- Arabic names are supported