using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanner.Configs;

internal class OrganizerConfig : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.ToTable("Organizers").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
        builder.Property(x => x.PhoneNumber).HasColumnName("Phone Number").IsRequired();
    }
}