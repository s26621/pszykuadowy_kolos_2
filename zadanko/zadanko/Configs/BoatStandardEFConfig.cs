using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanko.Models;

namespace zadanko.Configs;

public class BoatStandardEFConfig : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder
            .HasKey(x => x.IdBoatStandard)
            .HasName("BoatStandard_pk");
        builder
            .Property(x => x.IdBoatStandard)
            .ValueGeneratedNever();
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Level)
            .IsRequired();

        builder.ToTable(nameof(BoatStandard));

        BoatStandard[] boatStandards =
        {
            new() { IdBoatStandard = 1, Name = "tycia", Level = 2 },
            new() { IdBoatStandard = 2, Name = "malutka", Level = 1 },
            new() { IdBoatStandard = 3, Name = "taka sobie", Level = 3 },
            new() { IdBoatStandard = 4, Name = "jako tako", Level = 4 },
            new() { IdBoatStandard = 5, Name = "ujdzie", Level = 5 }
        };

        builder.HasData(boatStandards);
    }
}