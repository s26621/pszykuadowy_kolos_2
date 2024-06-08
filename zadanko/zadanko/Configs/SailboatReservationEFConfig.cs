using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanko.Models;

namespace zadanko.Configs;

public class SailboatReservationEFConfig : IEntityTypeConfiguration<SailboatReservation>
{
    public void Configure(EntityTypeBuilder<SailboatReservation> builder)
    {
        builder
            .HasKey(x => new { x.IdReservation, x.IdSailboat })
            .HasName("SailboatReservation_pk");
        builder
            .HasOne(x => x.Sailboat)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdSailboat)
            .HasConstraintName("SailboatReservation_Sailboat")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.Reservation)
            .WithMany(x => x.Sailboats)
            .HasForeignKey(x => x.IdReservation)
            .HasConstraintName("SailboatReservation_Reservation")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(SailboatReservation));

        SailboatReservation[] sailboatReservations =
        {
            new() { IdReservation = 1, IdSailboat = 1 },
            new() { IdReservation = 2, IdSailboat = 2 },
            new() { IdReservation = 3, IdSailboat = 3 },
        };

        builder.HasData(sailboatReservations);

    }
}