using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class PaleontologistConfig : IEntityTypeConfiguration<Paleontologist>
{
    public void Configure(EntityTypeBuilder<Paleontologist> builder)
    {
        builder.ToTable("Paleontologists").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.EducationId).HasColumnName("EducationId").IsRequired(true);

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(11).IsRequired(true);
        builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired(true);
        builder.Property(x => x.YearsOfExperience).HasColumnName("YearsOfExperience").IsRequired(true);
        builder.Property(x => x.ProfessionalRegisterId).HasColumnName("ProfessionalRegisterId").IsRequired(true);

        builder.HasOne(x => x.Education).WithOne().IsRequired(true);
    }
}