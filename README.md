# Student API

> **Note**: This is a simple educational project designed for learning purposes only. It demonstrates basic API development concepts using .NET and should not be used in production environments.

A .NET 9.0 Web API project that showcases fundamental concepts of building RESTful APIs, including:
- Basic CRUD operations
- Working with Arabic text
- API documentation
- Simple data validation
- Database seeding

## API Documentation Interface

After running the project, you can access the interactive API documentation through Scalar UI:

![Scalar UI Interface](images/scalar-ui-screenshot.png)

*Screenshot: Scalar UI showing the Student API endpoints and documentation*

## Educational Purpose

This project serves as a learning resource for:
- Beginning .NET developers
- Students learning Web API development
- Developers exploring Arabic language support in .NET
- Understanding basic API documentation with Scalar
- Learning Entity Framework Core basics

## Features

- CRUD operations for student management
- Pagination and search functionality
- In-memory database with sample data seeding
- Arabic name support
- Interactive API documentation using Scalar
- Middle Eastern phone number format validation

## Prerequisites

- .NET 9.0 SDK
- An IDE (Visual Studio, VS Code, or Rider)

## Quick Start

1. **Clone the repository**
```bash
git clone <repository-url>
cd StudentApi
```

2. **Build the project**
```bash
dotnet build
```

3. **Run the application**
```bash
dotnet run
```

4. **Access the API**
- API: https://localhost:7014
- Scalar UI: https://localhost:7014/scalar

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/students` | Get all students (paginated) |
| GET | `/api/students/{id}` | Get student by ID |
| POST | `/api/students` | Create new student |
| PUT | `/api/students/{id}` | Update existing student |
| DELETE | `/api/students/{id}` | Delete student |
| GET | `/api/students/search` | Search students with filters |

## Sample Request

```http
POST https://localhost:7014/api/students
Content-Type: application/json

{
    "name": "سارة الخالدي",
    "birthDate": "2001-06-15T00:00:00",
    "phone": "+966512345678",
    "gender": "Female"
}
```

## Project Structure

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

## Learning Resources

This project demonstrates:
- RESTful API design principles
- Entity Framework Core basics
- API documentation best practices
- Data validation techniques
- Internationalization basics
- Database seeding patterns

## Documentation

- [Setup Guide](docs/setup-guide.md)
- [API Documentation](docs/scalar-documentation.md)
- [Database Seeding](docs/database-seeding.md)
- [Models Documentation](docs/models.md)

## Technologies

- ASP.NET Core 9.0
- Entity Framework Core (In-Memory)
- Scalar (formerly Swagger UI)
- Microsoft.AspNetCore.OpenApi

## Limitations

As this is an educational project, it has several limitations:
- Uses in-memory database (data is lost when the application restarts)
- Basic validation only
- No authentication/authorization
- No logging implementation
- Limited error handling
- Not suitable for production use

## NuGet Packages

```xml
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
<PackageReference Include="Scalar.AspNetCore" Version="2.0.29" />
```

## Development

1. **Adding a New Endpoint**
   - Add the endpoint to `StudentsController.cs`
   - Document using XML comments
   - Add appropriate response types
   - Update Scalar documentation

2. **Modifying the Student Model**
   - Update `Student.cs`
   - Update database context if needed
   - Modify seeding logic in `DbSeeder.cs`
   - Update documentation

3. **Testing**
   - Use Scalar UI for manual testing
   - Use provided `StudentApi.http` file
   - Test with Postman or similar tools

## Configuration

The application uses default ASP.NET Core configuration with:
- Development environment settings
- In-memory database
- HTTPS redirection
- Scalar UI customization

## Notes

- The application uses an in-memory database for development
- All dates are stored in UTC
- Phone numbers follow international format
- Arabic names are fully supported
- Scalar UI is only available in development environment

## Contributing

While this is an educational project, contributions that improve its teaching value are welcome:
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

[MIT License](LICENSE)

## Disclaimer

This project is intended for educational purposes only and should not be used in production environments. It demonstrates basic concepts and may not include security features, optimizations, or best practices required for production applications.
