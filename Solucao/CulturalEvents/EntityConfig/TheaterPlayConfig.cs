using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class TheaterPlayConfig : IEntityTypeConfiguration<TheaterPlay>
{
    public void Configure(EntityTypeBuilder<TheaterPlay> builder)
    {
        builder.ToTable("TheaterPlays").HasKey(p => p.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.ArtistId).HasColumnName("ArtistID").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Date).HasColumnName("Date").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Location).HasColumnName("Location").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Capacity).HasColumnName("Capacity").IsRequired();
        builder.Property(x => x.Fee).HasColumnName("Fee").IsRequired();
        builder.Property(x => x.Cast).HasColumnName("Cast").IsRequired();

        builder.HasOne(c => c.Artist).WithMany().IsRequired();
    }
}