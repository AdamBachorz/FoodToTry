using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using Domain.Abstractions;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
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
}
