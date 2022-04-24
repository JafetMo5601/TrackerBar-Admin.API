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

        public async Task<List<Reservations>> GetReservationsByIdAsync(int restaurantId)
        {
            List<Reservations> result =  (from RD in context.ReceiptDetail
                          join R in context.Receipt on RD.ReceiptId equals R.ReceiptId
                          join U in context.User on R.User.Id equals U.Id
                          where RD.Restaurant.RestaurantId == restaurantId
                          select new Reservations(){
                              TableNumber = RD.TableNumber,
                              PeopleQty = RD.PeopleQty,
                              Name = U.Name,
                              Last = U.Last,
                              boughtAt = RD.boughtAt
                            }).ToList();
            return result;
        }

        // update perfil
         public async Task<User> UpdateUserProfile(DataModels.User updatedUser)
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
