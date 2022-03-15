using TrackerBar_Admin.API.DB;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLTableRepository : ITableRepository
    {
        private readonly ApplicationDBContext context;

        public SQLTableRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
public async Task<int> GetTotalTablesAsync()
        {
            var result = (from r in context.Restaurant
                          join s in context.ReceiptDetail
                          on r.RestaurantId equals s.Restaurant.RestaurantId
                          select r.PeopleQty - s.PeopleQty).First();
            return result;
        }
    }
}
