using System;
using ArcheologicalSite.Interfaces;

namespace ArcheologicalSite.Models
{
    public class Specialization : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Country { get; set; }
    }
}