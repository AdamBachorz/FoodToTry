using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using InfrastructureAbstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataBaseContext : BaseDbContext
{
    public DbSet<Food> Foods { get; set; }

    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Food>().HasData(
            new Food { Id = 1, RestaurantName = "Pierwsza restauracja", FoodItems = "Pizza;Kebab", }
        );
    }
}

