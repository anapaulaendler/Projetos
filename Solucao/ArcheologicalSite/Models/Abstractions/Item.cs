using ArcheologicalSite.Interfaces;

namespace ArcheologicalSite.Models
{
    public abstract class Item : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Period { get; set; }
        public required string Origin { get; set; }
    }
}