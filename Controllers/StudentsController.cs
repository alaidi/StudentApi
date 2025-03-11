using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(SchoolContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<Student>>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var skip = (page - 1) * pageSize;
        var take = pageSize;
         var totalCount = await context.Students.CountAsync();
        var students = await context.Students
            .OrderBy(s => s.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetById(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Create(Student student)
    {
        student.BirthDate = student.BirthDate.Date; // This will set time to 00:00:00
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Student>> Update(int id, Student student)
    {
        var existingStudent = await context.Students.FindAsync(id);
        if (existingStudent == null)
           return NotFound();

        existingStudent.Name = student.Name;
        existingStudent.BirthDate = student.BirthDate;
        existingStudent.Phone = student.Phone;
        existingStudent.Gender = student.Gender;

        await context.SaveChangesAsync();
        return Ok(existingStudent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        context.Students.Remove(student);
        await context.SaveChangesAsync();

        return NoContent();
    }
    [HttpGet("search")]
    public async Task<ActionResult<PaginatedList<Student>>> Search(
        [FromQuery] string? name = null,
        [FromQuery] string? phone = null,
        [FromQuery] Gender? gender = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(s => s.Name.Contains(name));
        }

        if (!string.IsNullOrWhiteSpace(phone))
        {
            query = query.Where(s => s.Phone.Contains(phone));
        }

        if (gender.HasValue)
        {
            query = query.Where(s => s.Gender == gender.Value);
        }

        var totalCount = await query.CountAsync();
        var skip = (page - 1) * pageSize;

        var students = await query
            .OrderBy(s => s.Name)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var result = new
        {
            totalCount,
            totalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
            currentPage = page,
            pageSize,
            data = students
        };

        return Ok(result);
    }
}
