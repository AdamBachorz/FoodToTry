using BachorzLibrary.DAL.DAO;
using Domain;
using InfrastructureAbstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureAbstractions.Repositories
{
    public interface IFoodRepository : IBaseDao<Food, int>
    {
        IList<Food> GetFoodsByState(FoodState foodState);
        IList<string> GetRestaurants();
    }
}
