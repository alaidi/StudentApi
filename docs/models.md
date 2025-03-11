# Models Documentation

## Gender Enum
```csharp
public enum Gender
{
    Male,
    Female
}
```

## Student Model
```csharp
public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Phone { get; set; }
    public Gender Gender { get; set; }
}
```

## PaginatedList Class
```csharp
public class PaginatedList<T>
{
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public List<T> Data { get; set; }
}
```