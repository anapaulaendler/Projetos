using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events").HasKey(p => p.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.ArtistId).HasColumnName("ArtistID").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Date).HasColumnName("Date").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Location).HasColumnName("Location").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Capacity).HasColumnName("Capacity").IsRequired();
        builder.Property(x => x.Fee).HasColumnName("Fee").IsRequired();

        builder.HasOne(c => c.Artist).WithMany().IsRequired();
    }
}