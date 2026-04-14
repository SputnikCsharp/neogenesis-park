using Microsoft.EntityFrameworkCore;
using NeoGenesisPark.Models;

namespace NeoGenesisPark.Data;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;
    
    public DbSet<Dinosaurio> Dinosaurios { get; set; }

    public AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dinosaurio>(entity =>
        {
            // Username debe ser único en toda la tabla
            entity.HasIndex(e => e.Username).IsUnique();

            // Email debe ser único en toda la tabla
            entity.HasIndex(e => e.Email).IsUnique();
        });
    }
}