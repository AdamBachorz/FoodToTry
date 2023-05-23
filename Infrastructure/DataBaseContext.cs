using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using InfrastructureAbstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataBaseContext : BaseDbContext
{
    public DbSet<Restaurant> Restaurants { get; set; }

    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant { Id = 1, Name = "Pierwsza restauracja", FoodItems = "Pizza;Kebab", }
        );
    }
}

