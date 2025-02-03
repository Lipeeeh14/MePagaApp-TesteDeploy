using MePagaBack.Data.Configuration.Mapping;
using MePagaBack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MePagaBack.Data;

public class MePagaDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DevedorMapping());
        modelBuilder.ApplyConfiguration(new DividaMapping());
    }

    public DbSet<Devedor> Devedor { get; set; }
    public DbSet<Divida> Divida { get; set; }
}