using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class FossilConfig : IEntityTypeConfiguration<Fossil>
{
    public void Configure(EntityTypeBuilder<Fossil> builder)
    {
        builder.ToTable("Fossils").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PaleontologistId).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Period).HasColumnName("Period").HasMaxLength(11).IsRequired(true);
        builder.Property(x => x.Period).HasColumnName("Period").IsRequired(true);
        builder.Property(x => x.Origin).HasColumnName("Origin").IsRequired(true);
        builder.Property(x => x.ScientificName).HasColumnName("ScientificName").IsRequired(true);
        builder.Property(x => x.Type).HasColumnName("Type").IsRequired(true);
        builder.Property(x => x.Species).HasColumnName("Species").IsRequired(false);
        builder.Property(x => x.Condition).HasColumnName("Condition").IsRequired(false);

        builder.HasOne(x => x.Paleontologist).WithMany().IsRequired(false);
    }
}