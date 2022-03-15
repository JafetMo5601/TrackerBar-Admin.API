namespace TrackerBar_Admin.API.Repositories
{
    public interface ITableRepository
    {
        Task<int> GetTotalTablesAsync();
    }
}
