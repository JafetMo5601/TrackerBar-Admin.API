using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDBContext context;

        public SQLUserRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserByIdAsync(string UserId)
        {
            var user = (from x in context.Users
                        where x.Id == UserId
                        select x).First();

            return user;
        }
    }
}
