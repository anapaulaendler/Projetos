namespace ArcheologicalSite.Models
{
    public record ArtefactCsvModel
    {

        public required string Name { get; set; }
        public required string Period { get; set; }
        public required string Origin { get; set; }
        public required string Type { get; set; }
        public string? Function { get; set; }
        public required string Dimension { get; set; }
        public required string Material { get; set; }

        public Guid? ArcheologistId { get; set; }
    }
}