using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/member")]
public class MemberController : ControllerBase
{
    private readonly AppDbContext _ctx;
    public MemberController(AppDbContext ctx)
    {
        _ctx = ctx;
    } 

    // POST SINGLE
    [HttpPost("single")]
    public ActionResult<Member> PostMember(Member m)
    {
        _ctx.Members.Add(m);
        _ctx.SaveChanges();

        return Ok(m);
    }

    // POST BULK
    [HttpPost("bulk")]
    public ActionResult<IEnumerable<Member>> PostMembers(List<Member> members)
    {
        _ctx.Members.AddRange(members);
        _ctx.SaveChanges();

        return Ok(members);
    }

    // GET
    [HttpGet]
    public ActionResult<IEnumerable<Member>> GetMembers()
    {
        return _ctx.Members.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Member> SearchMember(Guid id)
    {
        Member? member = _ctx.Members.FirstOrDefault(m => m.Id == id);

        if (member is null)
        {
            return NotFound("Member wasn't found.");
        }

        return Ok(member);
    }

    [HttpPut("{id}")]
    public ActionResult<Member> UpdateMember(Guid id, Member updatedMember)
    {
        Member? member = _ctx.Members.FirstOrDefault(m => m.Id == id);

        if (member is null)
        {
            return NotFound("Member wasn't found.");
        }

        member.Adress = updatedMember.Adress;
        member.Email = updatedMember.Email;
        member.Fine = updatedMember.Fine;
        member.Name = updatedMember.Name;
        member.PhoneNumber = updatedMember.PhoneNumber;

        _ctx.Members.Update(member);
        _ctx.SaveChanges();
        return Ok(member);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMember(Guid id)
    {
        Member? member = _ctx.Members.FirstOrDefault(m => m.Id == id);

        if (member is null)
        {
            return NotFound("Member wasn't found.");
        }

        _ctx.Members.Remove(member);
        _ctx.SaveChanges();
        return NoContent();
    }
}