using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanko.Models;

namespace zadanko.Configs;

public class ClientCategoryEFConfig : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder
            .HasKey(x => x.IdClientCatherogy)
            .HasName("ClientCategory_pk");

        builder
            .Property(x => x.IdClientCatherogy)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder.ToTable(nameof(ClientCategory));

        ClientCategory[] clientCategories =
        {
            new() { IdClientCatherogy = 1, DiscountPerc = 0, Name = "zwyczajny" },
            new() { IdClientCatherogy = 2, DiscountPerc = 20, Name = "nadzwyczajny" },
            new() { IdClientCatherogy = 3, DiscountPerc = 50, Name = "supcio" }
        };
        builder.HasData(clientCategories);
    }
}