using CleanArchDotNet.Domain.Entities;
using CleanArchDotNet.Infra.Data.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDotNet.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
