namespace TrackerBar_Admin.API.Repositories
{
    public interface ITableRepository
    {
        Task<int> GetTablesAvailablesAsync(int RestaurantId);
        Task<int> GetTotalTablesCountAsync(int RestaurantId);
        Task<int> GetSpacesAvailablesAsync(int RestaurantId);
        Task<int> GetPeopleInBarsync(int RestaurantId);
    }
}
