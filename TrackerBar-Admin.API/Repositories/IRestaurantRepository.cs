using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<int> GetReceiptDetailAsync();
    }
}
