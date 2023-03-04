using BachorzLibrary.DAL.DotNetSix.Repositories;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
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
    }
}
