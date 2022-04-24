using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IRestaurantDirectionRepository
    {
        Task<RestaurantDirection> GetRestaurantDirectionByIdAsync(int Direction);

    }
}
