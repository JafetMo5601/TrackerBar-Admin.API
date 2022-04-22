using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLRestaurantDIrectionRepository : IRestaurantDirectionRepository
    {
        private readonly ApplicationDBContext context;

        public SQLRestaurantDIrectionRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<RestaurantDirection> GetRestaurantDirectionByIdAsync(string Direction)
        {
            var direction = (from x in context.RestaurantDirection
                        where x.Direction == Direction
                        select x).First();

            return direction;
        }   
    }
}
