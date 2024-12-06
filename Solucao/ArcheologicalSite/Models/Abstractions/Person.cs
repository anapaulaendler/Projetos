using ArcheologicalSite.Interfaces;

namespace ArcheologicalSite.Models
{
    public abstract class Person : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public int ProfessionalRegisterId { get; set; }
        public required string Profession { get; set; }
    }
}