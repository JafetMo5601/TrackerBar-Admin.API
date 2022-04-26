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

        public async Task<RestaurantDirection> GetRestaurantDirectionAsync(int restaurantId)
        {
            var direction = (from R in context.Restaurant
                                join RD in context.RestaurantDirection on R.RestaurantId equals RD.RestaurantId
                                where R.RestaurantId == restaurantId
                                select RD).FirstOrDefault();
            return direction;
        }

        public async Task<RestaurantDirection> UpdateRestaurantDirectionAsync(int restaurantId, string direction)
        {
            var oldDirection = await GetRestaurantDirectionAsync(restaurantId);

            if (oldDirection != null)
            {
                oldDirection.Direction = direction;
            }
            else {
                oldDirection = new RestaurantDirection()
                {
                    RestaurantId = restaurantId,
                    Direction = direction
                };
            }

            var result = context.RestaurantDirection.Update(oldDirection);

            if (result != null) { 
                await context.SaveChangesAsync();
            }

            var newDirection = await GetRestaurantDirectionAsync(restaurantId);

            return newDirection;
        }

        public async Task<RestaurantDirection> createRestaurantDirection(int restaurantId, string direction) {
            if (direction != "") {
                var newDirection = new RestaurantDirection()
                {
                    Direction = direction,
                    RestaurantId = restaurantId
                };

                await context.RestaurantDirection.AddAsync(newDirection);
                await context.SaveChangesAsync();

                return newDirection;
            }
            return null;
        }
    }
}
