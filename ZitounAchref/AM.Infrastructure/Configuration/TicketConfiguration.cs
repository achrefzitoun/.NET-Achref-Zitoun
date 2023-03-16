using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(r => new {r.passengerFK, r.flightFK});
            builder.HasOne(p => p.passenger ).WithMany(x => x.tickets).HasForeignKey(t => t.passengerFK);
            builder.HasOne(p => p.flight ).WithMany(x => x.tickets).HasForeignKey(t => t.flightFK);

        }
    }
}
