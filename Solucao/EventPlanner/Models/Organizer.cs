namespace EventPlanner.Models;

using System;
using EventPlanner.Interfaces;

public class Organizer : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}