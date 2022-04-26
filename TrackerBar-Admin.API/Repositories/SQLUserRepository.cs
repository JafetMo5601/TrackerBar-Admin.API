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

        //get's user from database
        public async Task<User> GetUserByIdAsync(string userId)
        {
            try
            {

             var result = new User();
            //validates if user exist or not
            if(userExist(userId))
            {
                result = (from X in context.Users
                        where X.Id == userId
                        select X).First();

                return result;
            }
            return null;
            }

            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }
          
        }

        //get's only the userId from database
        public async Task<string> GetUserId(string userId)
        {

            try
            {
            var result = (from X in context.Users
                         where X.Id == userId
                         select X.Id).First();
            return result;
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }
           
        }
        //asks if user already exists or not in database
        public bool userExist(string userId)
        {
            try
            { 
                var result = (from X in context.Users
                          where X.Id == userId
                          select X.Id).FirstOrDefault();
            
            if(result != null)
            {
                return true;
            }
                return false;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return false;
            }
           
        }
    }
}
