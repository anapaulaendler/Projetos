namespace ArcheologicalSite.Models
{
    public class Fossil : Item
    {
        public required string ScientificName { get; set; }
        public required string Type { get; set; }
        public string? Species {get; set; }
        public string? Condition { get; set; }

        public int PaleontologistId { get; set; }
        public required Paleontologist Paleontologist { get; set; }
    }
}