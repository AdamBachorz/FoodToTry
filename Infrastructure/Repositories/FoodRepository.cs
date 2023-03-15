using BachorzLibrary.DAL.DotNetSix.Repositories;
using Domain;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FoodRepository : EFCBaseRepository<Food, DataBaseContext, int>, IFoodRepository
    {
        public FoodRepository(DataBaseContext db) : base(db)
        {
        }

        public IList<Food> GetFoodsByState(FoodState foodState) => 
            _db.Foods.Where(f => f.FoodState == foodState)
            .OrderByDescending(f => f.Id)
            .ToList();
    }
}
