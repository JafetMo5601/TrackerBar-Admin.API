using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DomainModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<DataModels.Restaurant>> GetRestaurantsAsync();
        Task<DataModels.Restaurant> UpdateRestaurantAsync(UpdateRestaurant restaurant);
        Task<DataModels.Restaurant> DeleteRestaurantAsync(DeleteRestaurant restaurant);
    }
}
