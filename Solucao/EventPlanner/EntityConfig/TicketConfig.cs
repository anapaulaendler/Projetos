using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanner.Configs;

internal class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.EventId).IsRequired();

        builder.Property(x => x.AtendeeName).HasColumnName("Atendee Name").IsRequired();
        builder.Property(x => x.PricePaid).HasColumnName("Price Paid").IsRequired();
        builder.Property(x => x.IsEarlyBird).HasColumnName("IsEarlyBird").IsRequired();

        builder.HasOne(x => x.Event).WithMany().IsRequired();
    }
}
