namespace ArcheologicalSite.Models
{
    public class Fossil : Item
    {
        public required string ScientificName { get; set; }
        public string? Species {get; set; }
        public string? Condition { get; set; }

        public Guid? PaleontologistId { get; set; }
        public Paleontologist? Paleontologist { get; set; }
    }
}