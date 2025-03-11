# Database Seeding Documentation

## Overview
The project includes a database seeder that populates the in-memory database with sample student data. The seeder creates 100 unique student records with Arabic names, following Middle Eastern naming conventions.

## Implementation Details

### Data Structure
The seeder uses three main data arrays:
1. Arabic Names (Male and Female)
2. Male Names (for middle names)
3. Arabic Last Names

```csharp
private static readonly (string Name, Gender Gender)[] ArabicNames =
[
    // Male Names
    ("محمد", Gender.Male), ("أحمد", Gender.Male), ("عمر", Gender.Male),
    ("علي", Gender.Male), ("يوسف", Gender.Male), ("إبراهيم", Gender.Male),
    // ... more names

    // Female Names
    ("فاطمة", Gender.Female), ("مريم", Gender.Female), ("زينب", Gender.Female),
    ("سارة", Gender.Female), ("نور", Gender.Female), ("هدى", Gender.Female),
    // ... more names
];

private static readonly string[] ArabicLastNames =
[
    "الهاشمي", "العمري", "السعيد", "المالكي", "الحسيني",
    // ... more last names
];
```

## Seeding Process

1. **Initialization**
   - Create a service scope
   - Get SchoolContext instance
   - Ensure database is created
   - Check if database is already seeded

2. **Data Generation**
   - Generate 100 unique student records
   - Each student record includes:
     - Unique full name (First + Middle + Last)
     - Gender
     - Birth date (18-25 years range)
     - Unique phone number (Iraqi format)

3. **Phone Number Format**
   - Format: +964XXX-XXX-XXXX
   - Prefix: +964 (Iraq country code)
   - Network code: 770-799
   - Unique random numbers for remaining digits

## Usage

The seeding is automatically triggered in `Program.cs`:

```csharp
// After building the application
var app = builder.Build();

// Seed the database
DbSeeder.Seed(app.Services);
```

## Sample Generated Data

Example of generated student records:

```json
{
    "id": 1,
    "name": "محمد عبدالله الهاشمي",
    "birthDate": "2003-08-15T00:00:00",
    "phone": "+964771234567",
    "gender": "Male"
},
{
    "id": 2,
    "name": "مريم خالد العمري",
    "birthDate": "2004-03-22T00:00:00",
    "phone": "+964782345678",
    "gender": "Female"
}
```

## Data Constraints

1. **Names**
   - First name: Can be male or female
   - Middle name: Always male (following Arab naming conventions)
   - Last name: From predefined family names
   - No duplicate full names allowed

2. **Birth Dates**
   - Range: 18-25 years from current date
   - Random month and day
   - Time component is set to midnight (00:00:00)

3. **Phone Numbers**
   - Format: +964XXX-XXX-XXXX
   - Network codes: 770-799
   - No duplicate phone numbers allowed

## Error Handling

- Checks for existing data before seeding
- Ensures unique full names
- Ensures unique phone numbers
- Uses a while loop to generate required number of records

## Best Practices

1. **When to Use**
   - Development environment
   - Testing scenarios
   - Demo setups

2. **When to Modify**
   - Adding new name patterns
   - Changing phone number formats
   - Adjusting age ranges
   - Adding new data fields

3. **Maintenance**
   - Update name lists as needed
   - Adjust phone number patterns for different regions
   - Modify age ranges for different scenarios