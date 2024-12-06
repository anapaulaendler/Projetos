using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ArcheologistConfig : IEntityTypeConfiguration<Archeologist>
{
    public void Configure(EntityTypeBuilder<Archeologist> builder)
    {
        builder.ToTable("Archeologists").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();;

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Cpf).HasColumnName("CPF").IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(x => x.ProfessionalRegisterId).HasColumnName("ProfessionalRegisterId").IsRequired();
        builder.Property(x => x.Profession).HasColumnName("Profession").IsRequired();

        builder.HasMany(x => x.Artefacts).WithOne(x => x.Archeologist).IsRequired(false);
    }
}