
namespace StudentApi.Data;

public static class DbSeeder
{
    private static readonly (string Name, Gender Gender)[] ArabicNames =
    [
        // Male Names
        ("محمد", Gender.Male), ("أحمد", Gender.Male), ("عمر", Gender.Male),
        ("علي", Gender.Male), ("يوسف", Gender.Male), ("إبراهيم", Gender.Male),
        ("خالد", Gender.Male), ("عبدالله", Gender.Male), ("حسن", Gender.Male),
        ("سعيد", Gender.Male), ("عبدالرحمن", Gender.Male), ("طارق", Gender.Male),
        ("زياد", Gender.Male), ("هشام", Gender.Male), ("كريم", Gender.Male),

        // Female Names
        ("فاطمة", Gender.Female), ("مريم", Gender.Female), ("زينب", Gender.Female),
        ("سارة", Gender.Female), ("نور", Gender.Female), ("هدى", Gender.Female),
        ("عائشة", Gender.Female), ("رنا", Gender.Female), ("لينا", Gender.Female),
        ("سلمى", Gender.Female), ("ليلى", Gender.Female), ("جنى", Gender.Female),
        ("ريم", Gender.Female), ("دانا", Gender.Female), ("ياسمين", Gender.Female)
    ];

    // Get only male names from ArabicNames
    private static readonly (string Name, Gender Gender)[] MaleNames =
        ArabicNames.Where(n => n.Gender == Gender.Male).ToArray();

    private static readonly string[] ArabicLastNames =
    [
        "الهاشمي", "العمري", "السعيد", "المالكي", "الحسيني",
        "الخالدي", "العبدالله", "الأحمد", "المحمد", "الصالح",
        "الناصر", "العلي", "الحمد", "السالم", "الرشيد",
        "القاسم", "البدر", "الزيد", "العثمان", "الفهد"
    ];

    public static void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchoolContext>();

        // Ensure database is created
        context.Database.EnsureCreated();

        // Check if database is already seeded
        if (context.Students.Any())
        {
            return;
        }

        var random = new Random();
        var students = new List<Student>();
        var usedNames = new HashSet<string>();
        var usedPhones = new HashSet<string>();

        int id = 1;
        while (students.Count < 100)
        {
            var (firstName, gender) = ArabicNames[random.Next(ArabicNames.Length)];
            var middleName = MaleNames[random.Next(MaleNames.Length)].Name;
            var lastName = ArabicLastNames[random.Next(ArabicLastNames.Length)];

            var fullName = $"{firstName} {middleName} {lastName}";

            // Generate phone number
            string phone;
            do
            {
                phone = $"+964{random.Next(770, 799)}{random.Next(100, 999):D3}{random.Next(1000, 9999):D4}";
            } while (usedPhones.Contains(phone));

            // Skip if name is already used
            if (usedNames.Contains(fullName))
                continue;

            usedNames.Add(fullName);
            usedPhones.Add(phone);

            students.Add(new Student
            {
                Id = id++,
                Name = fullName,
                Gender = gender,
                BirthDate = DateTime.Now.AddYears(-random.Next(18, 25))
                    .AddMonths(-random.Next(0, 12))
                    .AddDays(-random.Next(0, 31))
                    .Date,
                Phone = phone
            });
        }

        context.Students.AddRange(students);
        context.SaveChanges();
    }
}
