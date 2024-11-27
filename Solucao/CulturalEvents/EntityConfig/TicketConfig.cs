using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets").HasKey(p => p.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.EventId).IsRequired();
        builder.Property(x => x.ParticipantId).IsRequired();

        builder.Property(x => x.Price).HasColumnName("Price").IsRequired();
        builder.Property(x => x.Status).HasColumnName("Status").IsRequired();

        builder.HasOne(x => x.Event).WithMany().IsRequired();
        builder.HasOne(x => x.Participant).WithMany().IsRequired();
    }
}