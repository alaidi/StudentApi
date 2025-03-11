public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Phone { get; set; }
    public required Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}
