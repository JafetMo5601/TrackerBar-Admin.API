using Microsoft.EntityFrameworkCore;
using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLRestaurantRepository : IRestaurantRepository
    {
          
        private readonly ApplicationDBContext context;

        public SQLRestaurantRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        
        //obtener mesa disponibles 
        public async Task<User> GetReceiptDetailAsync()
        {
            var result = (from RD in context.ReceiptDetail
                          join R in context.Receipt on RD.ReceiptDetailId equals R.ReceiptId
                          join U in context.Users on R.ReceiptId equals U.Id
                          //where R.ReceiptId == R.ReceiptId
                          select new
                          {
                             RD.TableNumber,
                             R.ReceiptId,
                             U.Id,
                             U.Name
                          });
                          
                          
                          //RD.TableNumber).First();
                  
            return result;
        }

        // update perfil
         public async Task<User> GetUserUpdate(DataModels.User updatedUser)
         {
            var result = context.Users.SingleOrDefault(u => u.Id == updatedUser.Id);
            if(result == null)
            {
                context.Entry(result).CurrentValues.SetValues(updatedUser);
                context.SaveChanges();
            }

            return updatedUser;

         }

        public async Task<List<Restaurant>> GetRestaurantsAsync() { 
            return await context.Restaurant.Include(nameof(User)).Include(nameof(Direction)).ToListAsync();

        }

        
    }
}
