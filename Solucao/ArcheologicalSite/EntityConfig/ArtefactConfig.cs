using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ArtefactConfig : IEntityTypeConfiguration<Artefact>
{
    public void Configure(EntityTypeBuilder<Artefact> builder)
    {
        builder.ToTable("Artefacts").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.ArcheologistId).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Period).HasColumnName("Period").HasMaxLength(11).IsRequired(true);
        builder.Property(x => x.Period).HasColumnName("Period").IsRequired(true);
        builder.Property(x => x.Origin).HasColumnName("Origin").IsRequired(true);
        builder.Property(x => x.Function).HasColumnName("Function").IsRequired(false);
        builder.Property(x => x.Dimension).HasColumnName("Dimension").IsRequired(true);
        builder.Property(x => x.Material).HasColumnName("Material").IsRequired(true);

        builder.HasOne(x => x.Archeologist).WithMany().IsRequired(false);
    }
}