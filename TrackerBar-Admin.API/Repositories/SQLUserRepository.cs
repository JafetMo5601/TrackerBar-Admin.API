using Microsoft.EntityFrameworkCore;
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

        /*public async Task<User> GetUserByIdAsync(string UserId)
        {
            var user = (from x in context.Users
                        where x.Id == UserId
                        select x).First();
            return user;
        }*/

        public async Task<User> GetUserByIdAsync(string userId)
        {
            var result = new User();

            if(userExist(userId))
            {
                result = (from X in context.Users
                        where X.Id == userId
                        select X).First();

                return result;
            }
            return null;
        }


        public async Task<string> GetUserId(string userId)
        {
            var result = (from X in context.Users
                         where X.Id == userId
                         select X.Id).First();
            return result;
        }

        public bool userExist(string userId)
        {  
            var result = (from X in context.Users
                          where X.Id == userId
                          select X.Id).First();
            
            if(result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
