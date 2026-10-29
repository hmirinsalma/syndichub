using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SyndicHub.Domain.Entities;

namespace SyndicHub.Infrastructure.Data;

/// <summary>
/// Contexte de base de données principal de l'application
/// Hérite de IdentityDbContext pour intégrer ASP.NET Core Identity
/// </summary>
public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets (tables)
    public DbSet<Residence> Residences => Set<Residence>();
    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<Unit> Units => Set<Unit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration des entités
        ConfigureUser(modelBuilder);
        ConfigureResidence(modelBuilder);
        ConfigureBuilding(modelBuilder);
        ConfigureUnit(modelBuilder);
    }

    private void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.PasswordHash)
                .IsRequired();

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Index
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.ResidenceId);
            entity.HasIndex(e => e.IsDeleted);

            // Relations
            entity.HasOne(e => e.Residence)
                .WithMany(r => r.Users)
                .HasForeignKey(e => e.ResidenceId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureResidence(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Residence>(entity =>
        {
            entity.ToTable("Residence");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.CurrentBalance)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Index
            entity.HasIndex(e => e.IsDeleted);
        });
    }

    private void ConfigureBuilding(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.ToTable("Building");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Index
            entity.HasIndex(e => e.ResidenceId);
            entity.HasIndex(e => e.IsDeleted);

            // Relations
            entity.HasOne(e => e.Residence)
                .WithMany(r => r.Buildings)
                .HasForeignKey(e => e.ResidenceId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private void ConfigureUnit(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Area)
                .HasColumnType("decimal(10,2)");

            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Index
            entity.HasIndex(e => e.BuildingId);
            entity.HasIndex(e => e.ResidentId);
            entity.HasIndex(e => e.IsDeleted);

            // Relations
            entity.HasOne(e => e.Building)
                .WithMany(b => b.Units)
                .HasForeignKey(e => e.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Resident)
                .WithMany()
                .HasForeignKey(e => e.ResidentId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}
