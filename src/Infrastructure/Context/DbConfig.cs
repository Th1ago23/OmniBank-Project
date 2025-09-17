using Core.Entity;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security;

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

        var adminRoleId = Guid.NewGuid();
        var analystRoleId = Guid.NewGuid();
        var managerRoleId = Guid.NewGuid();
        var userRoleId = Guid.NewGuid();
        var supportRoleId = Guid.NewGuid();

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = adminRoleId, Name = RolesName.Admin, Description = "Administrador total" },
            new Role { Id = analystRoleId, Name = RolesName.Analyst, Description = "Analista financeiro" },
            new Role { Id = managerRoleId, Name = RolesName.Manager, Description = "Gerente" },
            new Role { Id = userRoleId, Name = RolesName.User, Description = "Usuário padrão" },
            new Role { Id = supportRoleId, Name = RolesName.Support, Description = "Suporte ao cliente" }
        );

        var createUserPermId = Guid.NewGuid();
        var editUserPermId = Guid.NewGuid();
        var deactivateUserPermId = Guid.NewGuid();
        var viewLogsPermId = Guid.NewGuid();
        var createReportPermId = Guid.NewGuid();
        var runQueryPermId = Guid.NewGuid();
        var approveReportPermId = Guid.NewGuid();

        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = createUserPermId, Name = "CreateUser", Description = "Pode criar usuários" },
            new Permission { Id = editUserPermId, Name = "EditUser", Description = "Pode editar usuários" },
            new Permission { Id = deactivateUserPermId, Name = "DeactivateUser", Description = "Pode desativar usuários" },
            new Permission { Id = viewLogsPermId, Name = "ViewLogs", Description = "Pode acessar logs e auditoria" },
            new Permission { Id = createReportPermId, Name = "CreateReports", Description = "Pode criar relatórios" },
            new Permission { Id = runQueryPermId, Name = "RunQueries", Description = "Pode rodar consultas" },
            new Permission { Id = approveReportPermId, Name = "ApproveReports", Description = "Pode aprovar relatórios" }
        );

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

        modelBuilder.Entity<Role>()
                  .HasMany(r => r.Permissions)
                  .WithMany(p => p.Roles)
                  .UsingEntity(j => j.ToTable("RolePermissions"));

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
