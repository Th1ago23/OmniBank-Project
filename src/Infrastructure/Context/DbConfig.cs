using Core.Entity;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DbConfig : DbContext
{
    public DbConfig(DbContextOptions<DbConfig> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> Tokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserLoginAttempt> UserLoginAttempts { get; set; }
    public DbSet<Adress> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.Username).IsUnique();

            entity.HasMany(u => u.Attempts)
                  .WithOne(a => a.User)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(u => u.Tokens)
                  .WithOne(t => t.User)
                  .HasForeignKey(t => t.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(i=> i.Adresses)
                  .WithOne(i => i.User)
                  .HasForeignKey(i=> i.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
            entity.HasIndex(r => r.Name).IsUnique();
        });

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));

        modelBuilder.Entity<UserLoginAttempt>(entity =>
        {
            entity.ToTable("UserLoginAttempts");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshTokens");
            entity.HasIndex(t => t.TokenHash).IsUnique();
        });
        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Alley).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Cep).IsRequired().HasMaxLength(9);
        });
    }
}
