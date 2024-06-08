using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanko.Models;

namespace zadanko.Configs;

public class ReservationEFConfig : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasKey(x => x.IdReservation)
            .HasName("Reservation_pk");
        builder
            .Property(x => x.IdReservation)
            .ValueGeneratedNever();

        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdClient)
            .HasConstraintName("Reservation_Client")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .Property(x=>x.DateFrom)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        builder
            .Property(x=>x.DateTo)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdBoatStandard)
            .HasConstraintName("Reservation_BoatStandard")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .Property(x => x.Capacity)
            .IsRequired();
        builder
            .Property(x => x.Fulfilled)
            .IsRequired();
        builder
            .Property(x => x.CancelReason)
            .HasMaxLength(200);

        builder.ToTable(nameof(Reservation));

        Reservation[] reservations =
        {
            new() {IdReservation = 1, IdClient = 1, DateFrom = new DateOnly(2024,05,10), DateTo = new DateOnly(2024,06,20), IdBoatStandard = 1, Capacity = 10, NumofBoats = 2, Fulfilled = 1, Price = 200},
            new() {IdReservation = 2, IdClient = 2, DateFrom = new DateOnly(2024,05,10), DateTo = new DateOnly(2024,05,10), IdBoatStandard = 2, Capacity = 15, NumofBoats = 3, Fulfilled = 2, Price = 400},
            new() {IdReservation = 3, IdClient = 3, DateFrom = new DateOnly(2024,06,01), DateTo = new DateOnly(2024,07,01), IdBoatStandard = 3, Capacity = 4, NumofBoats = 1, Fulfilled = 2, Price = 600}
        };

        builder.HasData(reservations);
    }
}