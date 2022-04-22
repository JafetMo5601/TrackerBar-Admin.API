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
        public async Task<int> GetReceiptDetailAsync()
        {
            var result = (from RD in context.ReceiptDetail
                          join R in context.Receipt
                          on RD.ReceiptDetailId equals R.ReceiptId
                          where R.ReceiptId == R.ReceiptId
                          select RD.TableNumber).First();
            
            return result;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync() { 
            return await context.Restaurant.Include(nameof(User)).Include(nameof(Direction)).ToListAsync();

        }
    }
}
