using DDDProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDProject.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().OwnsMany(o => o.Items);
    }
}
