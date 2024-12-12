using EventPlanner.Interfaces;

namespace EventPlanner.Models;
public class Event : IEntity
{
    public Guid Id { get; set; }
    public Guid OrganizerId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public int MaxAttendees { get; set; }
    public int CurrentAttendees { get; set; } // n de tickets
    
    public required Organizer Organizer { get; set; }
}