namespace ArcheologicalSite.Models
{
    public class Paleontologist : Person
    {
        public List<Fossil>? Fossils { get; set; }
    }
}