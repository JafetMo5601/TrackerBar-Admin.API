using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IRestaurantDirectionRepository
    {
        Task<RestaurantDirection> UpdateRestaurantDirectionAsync(int restaurantId, string direction);
        Task<RestaurantDirection> GetRestaurantDirectionAsync(int restaurantId);
        Task<RestaurantDirection> createRestaurantDirection(int restaurantId, string direction);

    }
}
