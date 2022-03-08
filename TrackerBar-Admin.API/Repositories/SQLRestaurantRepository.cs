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
    }
}
