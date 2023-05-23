using BachorzLibrary.DAL.DAO;
using Domain;
using InfrastructureAbstractions.Entities;

namespace InfrastructureAbstractions.Repositories
{
    public interface IFoodRepository : IBaseDao<Restaurant, int>
    {
        IList<Restaurant> GetRestaurnatsByState(State foodState);
        IList<string> GetRestaurants();
        IList<Restaurant> GetOrderedRestaurants();
    }
}
