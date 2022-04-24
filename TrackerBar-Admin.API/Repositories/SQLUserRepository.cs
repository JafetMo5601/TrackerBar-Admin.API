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


        public async Task<User> GetUserAsync(string userId)
        {
            var result = new User();

                    if(GetUserExist(userId).Equals(true))
                    {
                      result = (from X in context.Users
                              where X.Id == userId
                              select X).First();

                      return result;
                    }
                       return result;
            
        }


        public async Task<string> GetUserId(string userId)
        {

            var result = (from X in context.Users
                         where X.Id == userId
                         select X.Id).First();

            return result;
        }

        public async Task<bool> GetUserExist(string userId)
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
