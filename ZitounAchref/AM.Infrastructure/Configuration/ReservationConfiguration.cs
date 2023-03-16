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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => new { r.passengerFK, r.seatFK, r.DateReservation });
            builder.HasOne(r => r.passenger).WithMany(r => r.reservations).HasForeignKey(r => r.passengerFK);
            builder.HasOne(r => r.seat).WithMany(r => r.reservations).HasForeignKey(r => r.seatFK);
        }
    }
}
