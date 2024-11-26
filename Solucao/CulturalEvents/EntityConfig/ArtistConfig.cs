using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ArtistConfig : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists").HasKey(p => p.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(14).IsFixedLength().IsRequired();
        builder.Property(x => x.Email).HasColumnName("E-mail").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Speciality).HasColumnName("Speciality").HasMaxLength(100).IsRequired();
    }
}