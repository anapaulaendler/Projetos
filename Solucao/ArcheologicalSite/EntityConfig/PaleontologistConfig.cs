using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class PaleontologistConfig : IEntityTypeConfiguration<Paleontologist>
{
    public void Configure(EntityTypeBuilder<Paleontologist> builder)
    {
        builder.ToTable("Paleontologists").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(11).IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(x => x.ProfessionalRegisterId).HasColumnName("ProfessionalRegisterId").IsRequired();
        builder.Property(x => x.Profession).HasColumnName("Profession").IsRequired();

        builder.HasMany(x => x.Fossils).WithOne(x => x.Paleontologist).IsRequired(false);
    }
}