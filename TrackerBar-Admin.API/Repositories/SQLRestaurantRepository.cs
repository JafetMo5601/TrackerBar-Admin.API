using Microsoft.EntityFrameworkCore;
using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;
using TrackerBar_Admin.API.DomainModels;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLRestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDBContext context;
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantDirectionRepository _restaurantDirectionRepository;

        public SQLRestaurantRepository(ApplicationDBContext context, IUserRepository userRepository)
        {
            this.context = context;
            _userRepository = userRepository;
        }

        public async Task<List<DataModels.Restaurant>> GetRestaurantsAsync() {
            return await context.Restaurant.Include(nameof(DataModels.User)).Include(nameof(DataModels.Direction)).ToListAsync();

        }

        public async Task<DataModels.Restaurant> UpdateRestaurantAsync(UpdateRestaurant updateRestaurant)
        {
            var restaurant = (from x in context.Restaurant
                              where x.RestaurantId == updateRestaurant.RestaurantId
                              select x).First();

            restaurant.Name = updateRestaurant.Name;
            restaurant.PeopleQty = updateRestaurant.PeopleQty;
            restaurant.TableQty = updateRestaurant.TableQty;
            restaurant.EmployeeQty = updateRestaurant.EmployeeQty;
            restaurant.Phone = updateRestaurant.Phone;

            var direction = await _restaurantDirectionRepository.GetRestaurantDirectionByIdAsync(updateRestaurant.Direccion);
            restaurant.Direction = direction;

            var user = await _userRepository.GetUserByIdAsync(updateRestaurant.UserId);
            restaurant.User = user;

            context.Restaurant.Update(restaurant);

            await context.SaveChangesAsync();

            return restaurant;
        }

        public Task<DataModels.Restaurant> DeleteRestaurantAsync(DeleteRestaurant restaurant)
        {

            var deleteBar = (from x in context.Restaurant
                             where x.RestaurantId == restaurant.RestaurantId
                             select x).First();

            if (deleteBar == null)
            {
                throw new Exception("El restaurante no existe");
            }
            else
            {

            }
            

            throw new NotImplementedException();
        }







        /*public Task<Restaurant> DeleteRestaurantAsync(string nombre, string direccion)
{
    var result = (from x in context.Restaurant
                  where x.Name == nombre && x.Direction == direccion
                  select x).FirstOrDefault();

    if (result != null)
    {
        context.Entry(dep).State = System.Data.Entity.EntityState.Deleted;
        context.SaveChanges();
    }
    context.Dispose();

    return restaurant;
}*/




        /*var newDirection _restaurantDirectionRepository(restaurant.RestaurantId);
        newDirection.Direction - updateRestaurant.Direccion


        restaurant.Direction = newDirection;*/



        /*var result = (from x in context.Restaurant
                         where x.RestaurantId == restaurant.RestaurantId
                         select x).FirstOrDefault();

        if (result != null)
        {
            context.Entry(result).CurrentValues.SetValues(restaurant);
            context.SaveChanges();
        }
        context.Dispose();

        return restaurant;

        /*var result = context.Restaurant.SingleOrDefault(u => u.RestaurantId == restaurant.RestaurantId);

            if (result != null)
            {
            context.Entry(result).CurrentValues.SetValues(restaurant);
            context.SaveChanges();
            }

        return restaurant;*/

        /*public async Task<DataModels.RestaurantDirection> GetURestaurantDirectionByIdAsync(string Direccion)
        {
            var user = (from x in context.RestaurantDirection
                        where x.RestaurantDirectionId == Direccion
                        select x).First();

            return user;
        }*/
    }
}
