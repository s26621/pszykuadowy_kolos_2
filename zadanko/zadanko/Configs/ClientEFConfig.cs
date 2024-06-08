using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanko.Models;

namespace zadanko.Configs;

public class ClientEFConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasKey(x => x.IdClient)
            .HasName("Client_pk");

        builder
            .Property(x => x.IdClient)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Birthday)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        
        builder
            .Property(x => x.Pesel)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasOne(x => x.ClientCategory)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.IdClientCategory)
            .HasConstraintName("Client_ClientCategory")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(Client));

        Client[] clients =
        {
            new () {IdClient = 1, Name = "Jan", LastName = "Kowalski", Birthday = new DateOnly(2000,12,23),Email = "jan.kowalski@gmailcom", IdClientCategory = 1, Pesel = "1234567890"},
            new () {IdClient = 1, Name = "Tomasz", LastName = "Problem", Birthday = new DateOnly(1995,4,11),Email = "tomasz.problem@gmailcom", IdClientCategory = 2, Pesel = "023452341"},
            new () {IdClient = 1, Name = "Adam", LastName = "Ciwryj", Birthday = new DateOnly(1989,07,17),Email = "adam.ciwryj@gmailcom", IdClientCategory = 3, Pesel = "3562758391"}
        };

        builder.HasData(clients);

    }
}