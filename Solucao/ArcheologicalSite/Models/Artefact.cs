namespace ArcheologicalSite.Models
{
    public class Artefact : Item
    {
        public string? Function { get; set; }
        public required string Dimension { get; set; }
        public required string Material { get; set; }

        public Guid? ArcheologistId { get; set; }
        public Archeologist? Archeologist { get; set; }
    }
}