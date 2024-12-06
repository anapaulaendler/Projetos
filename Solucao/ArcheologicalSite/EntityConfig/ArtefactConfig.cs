using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ArtefactConfig : IEntityTypeConfiguration<Artefact>
{
    public void Configure(EntityTypeBuilder<Artefact> builder)
    {
        builder.ToTable("Artefacts").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.ArcheologistId).IsRequired(false);

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Period).HasColumnName("Period").IsRequired();
        builder.Property(x => x.Period).HasColumnName("Period").IsRequired();
        builder.Property(x => x.Origin).HasColumnName("Origin").IsRequired();
        builder.Property(x => x.Function).HasColumnName("Function").IsRequired(false);
        builder.Property(x => x.Dimension).HasColumnName("Dimension").IsRequired();
        builder.Property(x => x.Material).HasColumnName("Material").IsRequired();
        builder.Property(x => x.Type).HasColumnName("Type").IsRequired();

        builder.HasOne(x => x.Archeologist).WithMany(x => x.Artefacts).IsRequired(false);
    }
}