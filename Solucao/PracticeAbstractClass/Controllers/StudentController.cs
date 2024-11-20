using Microsoft.AspNetCore.Mvc;
using PracticeAbstractClass.Models;

namespace PracticeAbstractClass.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _ctx;
    public StudentController(AppDbContext ctx)
    {
        _ctx = ctx;
    } 

    [HttpPost("single")]
    public ActionResult<Student> PostStudent([FromBody] Student student)
    {
        _ctx.Students.Add(student);
        _ctx.SaveChanges();

        return CreatedAtAction(nameof(GetStudent), new {id = student.Id}, student);
    }  

    [HttpPost("bulk")]
    public ActionResult<IEnumerable<Student>> PostStudents([FromBody] List<Student> students)
    {
        _ctx.Students.AddRange(students);
        _ctx.SaveChanges();

        return Ok(students);
    }   

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetStudents()
    {
        var studentDetails = _ctx.Students
        .ToList()
        .Select(x => x.ExibirDetalhes())
        .ToList();

        return Ok(studentDetails);
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetStudent(Guid id)
    {
        var student = _ctx.Students
        .FirstOrDefault(x => x.Id == id);

        if (student is null)
        {
            return NotFound();
        }

        return student.ExibirDetalhes();
    }

    [HttpPut("{id}")]
    public ActionResult<Student> UpdateStudent(Guid id, Student s)
    {
        var student = _ctx.Students
        .FirstOrDefault(x => x.Id == id);

        if (student is null)
        {
            return NotFound();
        }

        student.Age = s.Age;
        student.Major = s.Major;
        student.Name = s.Name;

        _ctx.Update(student);
        _ctx.SaveChanges();

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(Guid id)
    {
        var student = _ctx.Students
        .FirstOrDefault(x => x.Id == id);

        if (student is null)
        {
            return NotFound();
        }    

        _ctx.Remove(student);
        _ctx.SaveChanges();

        return NoContent();   
    }

}
