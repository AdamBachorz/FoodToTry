using BachorzLibrary.DAL.DotNetSix.Repositories;
using Domain;
using InfrastructureAbstractions.Entities;
using InfrastructureAbstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FoodRepository : EFCBaseRepository<Restaurant, DataBaseContext, int>, IFoodRepository
    {
        public FoodRepository(DataBaseContext db) : base(db)
        {
        }

        public IList<Restaurant> GetRestaurnatsByState(State foodState) => 
            _db.Restaurants.Where(f => f.State == foodState)
            .OrderByDescending(f => f.Id)
            .ToList();

        public IList<Restaurant> GetOrderedRestaurants()
        {
            return _db.Restaurants
                .OrderBy(r => r.State)
                .ThenBy(r => r.Id)
                .ToList();
        }

        public IList<string> GetRestaurants() =>
            _db.Restaurants
            .Select(f => f.Name)
            .Union(Codes.PopuladBrands)
            .Distinct().ToList();
    }
}
