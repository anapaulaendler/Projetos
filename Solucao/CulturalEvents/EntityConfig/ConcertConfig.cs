using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ConcertConfig : IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.ToTable("Concerts").HasKey(p => p.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.ArtistId).HasColumnName("ArtistID").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Date).HasColumnName("Date").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Location).HasColumnName("Location").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Capacity).HasColumnName("Capacity").IsRequired();
        builder.Property(x => x.Fee).HasColumnName("Fee").IsRequired();
        builder.Property(x => x.MusicGenre).HasColumnName("MusicGenre").HasMaxLength(15).IsRequired();

        builder.HasOne(c => c.Artist).WithMany(a => a.Concerts).IsRequired(false);
    }
}