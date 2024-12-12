using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanner.Configs;

internal class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.OrganizerId).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").IsRequired(false);
        builder.Property(x => x.Date).HasColumnName("Date").IsRequired();
        builder.Property(x => x.Location).HasColumnName("Location").IsRequired();
        builder.Property(x => x.Price).HasColumnName("Price").IsRequired();
        builder.Property(x => x.MaxAttendees).HasColumnName("MaxAttendees").IsRequired();
        builder.Property(x => x.CurrentAttendees).HasColumnName("CurrentAttendees").IsRequired();

        builder.HasOne(x => x.Organizer).WithMany().IsRequired();
    }
}