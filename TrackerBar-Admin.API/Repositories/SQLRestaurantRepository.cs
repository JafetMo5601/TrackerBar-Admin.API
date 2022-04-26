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

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            try
            {

            return await context.Restaurant.Include(nameof(User)).Include(nameof(RestaurantDirection)).ToListAsync();

            }
            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }
        }

        public async Task<YourRestaurantById> GetRestaurantByIdAsync(int restaurantId)
        {
            try
            {

                var restaurant = (from R in context.Restaurant
                                  join RD in context.RestaurantDirection on R.RestaurantId equals RD.RestaurantId
                                  where R.RestaurantId == restaurantId
                                  select new YourRestaurantById(){
                                      id = R.RestaurantId,
                                      name = R.Name,
                                      tablesQty = R.TableQty,
                                      peopleQty = R.PeopleQty,
                                      employeeQty = R.EmployeeQty,
                                      address = RD.Direction,
                                      phone = R.Phone
                                  }).FirstOrDefault();
                return restaurant;

            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }

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

                restaurant = await GetYourRestaurant(updateRestaurant.Name);

                return restaurant;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return null;
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
        //gets restaurant's name from database
        public async Task<string> GetNameRestaurant(string RestaurantName)
        {
            try
            {
                var result = (from X in context.Restaurant
                              where X.Name == RestaurantName
                              select X.Name).First();

                return result;

            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }

        }
        //ask if restaurant already exists or not in the database
        public bool restaurantExist(string RestaurantName)
        {
            try
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
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }

        }
        //shows owned restaurant to owner, apppears one who has same name as parameter
        public async Task<Restaurant> GetYourRestaurant(string RestaurantName)
        {
            try
            {
                //validates if restaurant already exists in database
                if (restaurantExist(RestaurantName))
                {
                    return await context.Restaurant.Include(nameof(User)).Include(nameof(RestaurantDirection)).FirstOrDefaultAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }
        }

        //Add new restaurant to database
        public async Task<Restaurant> AddRestaurant(AddRestaurant newRestaurant)
        {

            try
            {
                var user = await _userRepository.GetUserByIdAsync(newRestaurant.UserId);

                if (user != null)
                {
                    //create new restaurant
                    Restaurant res = new Restaurant()
                    {
                        Name = newRestaurant.RestaurantName,
                        PeopleQty = newRestaurant.PeopleQty,
                        TableQty = newRestaurant.TableQty,
                        Phone = newRestaurant.Phone,
                        User = user,
                        RestaurantDirection = null,
                    };

                    //add newRestaurant to database
                    await context.Restaurant.AddAsync(res);
                    await context.SaveChangesAsync();

                    return res;
                }

                    return null;
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }
        }

        public async Task<List<YourRestaurantsResponse>> GetYourRestaurantsAsync(string userId)
        {
            try
            {
                var restaurantsOwned = await (from R in context.Restaurant
                                              join RD in context.RestaurantDirection on R.RestaurantId equals RD.RestaurantId
                                              where R.User.Id == userId
                                              select new YourRestaurantsResponse(){ id = R.RestaurantId, name = R.Name }).ToListAsync();

                if (restaurantsOwned != null) {                
                    return restaurantsOwned;
                }
                return null;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }
        }

        public async Task<List<ReservationResponse>> GetReservationsByIdAsync(int restaurantId)
        {
            try
            {
                var reservations = await (from RD in context.ReceiptDetail
                                    join R in context.Receipt on RD.ReceiptId equals R.ReceiptId
                                    join U in context.User on R.User.Id equals U.Id
                                    select new ReservationResponse(){
                                        id = RD.ReceiptDetailId,
                                        owner = U.Name + " " + U.Last,
                                        details = "Table #" + RD.TableNumber + " for " + RD.PeopleQty + " people.",
                                        date = RD.boughtAt,
                                    }).ToListAsync();

                if (reservations != null) { 
                    return reservations;
                }
                return null;
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
