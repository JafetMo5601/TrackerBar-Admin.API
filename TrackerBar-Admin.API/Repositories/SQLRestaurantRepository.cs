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
            return await context.Restaurant.Include(nameof(User)).Include(nameof(Direction)).ToListAsync();

        }
    }
}
