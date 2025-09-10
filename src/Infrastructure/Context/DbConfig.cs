using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;
public class DbConfig:DbContext
{
    public DbConfig(DbContextOptions<DbConfig> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
