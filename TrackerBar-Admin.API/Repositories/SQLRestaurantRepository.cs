using Microsoft.EntityFrameworkCore;
using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLRestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDBContext context;
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantDirectionRepository _restaurantDirectionRepository;

        public SQLRestaurantRepository(ApplicationDBContext context, IUserRepository userRepository, IRestaurantDirectionRepository restaurantDirectionRepository)
        {
            this.context = context;
            _userRepository = userRepository;
            _restaurantDirectionRepository = restaurantDirectionRepository;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync() {
            return await context.Restaurant.Include(nameof(User)).Include(nameof(RestaurantDirection)).ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId) {
            var restaurant = (from R in context.Restaurant
                              where R.RestaurantId == restaurantId
                              select R).Include(nameof(User)).Include(nameof(RestaurantDirection)).FirstOrDefault();
            return restaurant;
        }

        public async Task<Restaurant> UpdateRestaurantAsync(UpdateRestaurants updateRestaurant)
        {
            try
            {
                var restaurant = await (from x in context.Restaurant
                                  where x.RestaurantId == updateRestaurant.RestaurantId
                                  select x).FirstAsync();

                if (restaurant != null)
                {
                    restaurant.Name = updateRestaurant.Name;
                    restaurant.PeopleQty = updateRestaurant.PeopleQty;
                    restaurant.TableQty = updateRestaurant.TableQty;
                    restaurant.EmployeeQty = updateRestaurant.EmployeeQty;
                    restaurant.Phone = updateRestaurant.Phone;

                    var newDirection = await _restaurantDirectionRepository.UpdateRestaurantDirectionAsync(updateRestaurant.RestaurantId, updateRestaurant.Direction);
                    var user = await _userRepository.GetUserByIdAsync(updateRestaurant.UserId);
                    
                    restaurant.RestaurantDirection = newDirection;
                    restaurant.User = user;

                    context.Restaurant.Update(restaurant);
                    await context.SaveChangesAsync();
                }

                restaurant = await GetRestaurantByIdAsync(updateRestaurant.RestaurantId);

                return restaurant;
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }
        }

        public async Task<Restaurant> DeleteRestaurantAsync(DeleteRestaurant deleteRestaurant)
        {
            try
            {
                var barToDelete = await (from x in context.Restaurant
                                         where x.RestaurantId == deleteRestaurant.RestaurantId && x.User.Id == deleteRestaurant.UserId
                                         select x).FirstOrDefaultAsync();

                if (barToDelete != null)
                {
                    var directionToDelete = (from x in context.RestaurantDirection
                                             where x.RestaurantId == deleteRestaurant.RestaurantId
                                             select x).First();

                    context.RestaurantDirection.Remove(directionToDelete);
                    context.Restaurant.Remove(barToDelete);

                    await context.SaveChangesAsync();

                    return barToDelete;
                }
                return null;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }
        }

        public async Task<string> GetNameRestaurant(string RestaurantName)
        {
            var result = (from X in context.Restaurant
                          where X.Name == RestaurantName
                          select X.Name).First();

            return result;
        }

        public bool restaurantExist(string RestaurantName)
        {
            var result = (from X in context.Restaurant
                          where X.Name == RestaurantName
                          select X.Name).FirstOrDefault();
            
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Restaurant> GetYourRestaurant(string RestaurantName)
        {
            if (restaurantExist(RestaurantName))
            {
                return await context.Restaurant.Include(nameof(User)).Include(nameof(RestaurantDirection)).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<Restaurant> AddRestaurant(AddRestaurant newRestaurant)
        {
            var user = await _userRepository.GetUserByIdAsync(newRestaurant.UserId);

            if (user != null) {
                Restaurant res = new Restaurant()
                {
                    Name = newRestaurant.RestaurantName,
                    PeopleQty = newRestaurant.PeopleQty,
                    TableQty = newRestaurant.TableQty,
                    Phone = newRestaurant.Phone,
                    User = user,
                    RestaurantDirection = null,
                };

                await context.Restaurant.AddAsync(res);
                await context.SaveChangesAsync();

                return res;
            }

            return null;
        }
    }
}
