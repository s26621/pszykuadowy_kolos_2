using Microsoft.EntityFrameworkCore;
using zadanko.Configs;
using zadanko.Models;

namespace zadanko.Context;

public class BoatRentalDbContext : DbContext
{
    public virtual DbSet<BoatStandard> BoatStandards { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientCategory> ClientCategories { get; set; }
    public virtual DbSet<Reservation> Reservations { get; set; }
    public virtual DbSet<Sailboat> Sailboats { get; set; }
    public virtual DbSet<SailboatReservation> SailboatReservations { get; set; }

    public BoatRentalDbContext()
    {
        
    }

    public BoatRentalDbContext(DbContextOptions<BoatRentalDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoatStandardEFConfig).Assembly);
    }
}