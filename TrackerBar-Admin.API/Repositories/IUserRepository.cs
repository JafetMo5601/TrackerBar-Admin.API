using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string UserId);
        Task<User> GetUserAsync(string userId);
        Task<string> GetUserId(string userId);
        Task<bool> GetUserExist(string userId);
    }
}
