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
        public async Task<List<Restaurant>> GetRestaurantsAsync() {
            return await context.Restaurant.Include(nameof(User)).Include(nameof(Direction)).ToListAsync();

        }

        public async Task<string> GetNameRestaurant(string RestaurantName)
        {
            var result = (from X in context.Restaurant
                          where X.Name == RestaurantName
                          select X.Name).First();

            return result;
        }

        public async Task<bool> GetRestaurantExist(string RestaurantName)
        {
            var result = (from X in context.Restaurant
                          where X.Name == RestaurantName
                          select X.Name).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Restaurant> GetYourRestaurant(string RestaurantName)
        {
            if(GetRestaurantExist(RestaurantName).Equals(true)){
                return await context.Restaurant.Include(nameof(User)).Include(nameof(Direction)).FirstOrDefaultAsync();
            }
                return null;
        }

        public async Task<Restaurant> AddRestaurant(AddRestaurant newRestaurant)
        {
            //var result =   context.Restaurant
            //              .Select(newRestaurant => new Restaurant
            //              {
            //                  RestaurantId = newRestaurant.RestaurantId,
            //                  Name = newRestaurant.Name,
            //                  PeopleQty = newRestaurant.PeopleQty,
            //                  TableQty = newRestaurant.TableQty,
            //                  Phone = newRestaurant.Phone,
            //                  User = newRestaurant.User,
            //                  Direction = newRestaurant.Direction
            //              }).FirstOrDefault();
            //                  return result;

            Restaurant res = new Restaurant();
            res.RestaurantId = newRestaurant.RestaurantId;
            res.Name = newRestaurant.Name;
            res.PeopleQty = newRestaurant.PeopleQty;
            res.TableQty = newRestaurant.TableQty;
            res.Phone = newRestaurant.Phone;
            res.User.Id = newRestaurant.UserId;
            res.Direction.Direction = newRestaurant.Direction;

            context.Restaurant.Add(res);
            context.SaveChanges();
            return res;


         }
    }
}
