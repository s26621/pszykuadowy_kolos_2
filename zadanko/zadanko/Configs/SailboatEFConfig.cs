using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanko.Models;

namespace zadanko.Configs;

public class SailboatEFConfig : IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        builder
            .HasKey(x => x.IdSailboat)
            .HasName("Sailboat_pk");
        builder
            .Property(x => x.IdSailboat)
            .ValueGeneratedNever();
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Capacity)
            .IsRequired();
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Sailboats)
            .HasForeignKey(x => x.IdBoatStandard)
            .HasConstraintName("Sailboat_BoatStandard")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .Property(x => x.Price)
            .IsRequired();

        builder.ToTable(nameof(Sailboat));

        Sailboat[] sailboats =
        {
            new() {IdSailboat = 1, Name = "AAAAA", Capacity = 2, Description = "onie", IdBoatStandard = 1, Price = 100},
            new() {IdSailboat = 2, Name = "BBBBBB", Capacity = 3, Description = "otak", IdBoatStandard = 2, Price = 200},
            new() {IdSailboat = 3, Name = "no elo", Capacity = 4, Description = "ojak", IdBoatStandard = 3, Price = 300},
        };

        builder.HasData(sailboats);
    }
}