using ArcheologicalSite.Interfaces;

namespace ArcheologicalSite.Models
{
    public class Education : IEntity
    {
        public Guid Id { get; set; }
        public required string Degree { get; set; }
        public required string University { get; set; }

        public required string SpecializationId { get; set; }
        public required Specialization Specialization { get; set; }
    }
}