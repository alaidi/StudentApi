using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using StudentApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register services
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseInMemoryDatabase("SchoolDb"));

var app = builder.Build();

// Seed the database
DbSeeder.Seed(app.Services);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Student API";
        options.Theme = ScalarTheme.Saturn;
        options.HideClientButton = true;
    });

}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
