namespace ArcheologicalSite.Models
{
    public record FossilCsvModel
    {

        public required string Name { get; set; }
        public required string Period { get; set; }
        public required string Origin { get; set; }
        public required string Type { get; set; }
        public required string ScientificName { get; set; }
        public string? Species { get; set; }
        public string? Condition { get; set; }

        public Guid? PaleontologistId { get; set; }
    }
}