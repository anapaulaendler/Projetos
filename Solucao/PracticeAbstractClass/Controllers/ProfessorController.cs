using Microsoft.AspNetCore.Mvc;
using PracticeAbstractClass.Models;

namespace PracticeAbstractClass.Controllers;

[ApiController]
[Route("api/professor")]
public class ProfessorController : ControllerBase
{
    private readonly AppDbContext _ctx;
    public ProfessorController(AppDbContext ctx)
    {
        _ctx = ctx;
    } 

    [HttpPost("single")]
    public ActionResult<Professor> PostProfessor([FromBody] Professor professor)
    {
        _ctx.Professors.Add(professor);
        _ctx.SaveChanges();

        return CreatedAtAction(nameof(GetProfessor), new {id = professor.Id}, professor);
    }  

    [HttpPost("bulk")]
    public ActionResult<IEnumerable<Professor>> PostProfessors([FromBody] List<Professor> professors)
    {
        _ctx.Professors.AddRange(professors);
        _ctx.SaveChanges();

        return Ok(professors);
    }   

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetProfessors()
    {
        var professorDetails = _ctx.Professors
        .ToList()
        .Select(x => x.ExibirDetalhes())
        .ToList();

        return Ok(professorDetails);
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetProfessor(Guid id)
    {
        var professor = _ctx.Professors
        .FirstOrDefault(x => x.Id == id);

        if (professor is null)
        {
            return NotFound();
        }

        return professor.ExibirDetalhes();
    }

    [HttpPut("{id}")]
    public ActionResult<Professor> UpdateProfessor(Guid id, Professor s)
    {
        var professor = _ctx.Professors
        .FirstOrDefault(x => x.Id == id);

        if (professor is null)
        {
            return NotFound();
        }

        professor.Age = s.Age;
        professor.Course = s.Course;
        professor.Name = s.Name;

        _ctx.Update(professor);
        _ctx.SaveChanges();

        return Ok(professor);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProfessor(Guid id)
    {
        var professor = _ctx.Professors
        .FirstOrDefault(x => x.Id == id);

        if (professor is null)
        {
            return NotFound();
        }    

        _ctx.Remove(professor);
        _ctx.SaveChanges();

        return NoContent();   
    }

}
