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

        public async Task<int> GetPeopleInBarsync(int RestaurantId)
        {
            var result = (from RD in context.ReceiptDetail
                          where RD.Restaurant.RestaurantId == RestaurantId
                          select RD.PeopleQty).Sum();
            return result;
        }

        public async Task<int> GetSpacesAvailablesAsync(int RestaurantId)
        {
            var invoice_people_qty = (from RD in context.ReceiptDetail
                                      where RD.Restaurant.RestaurantId == RestaurantId
                                      select RD.PeopleQty).Sum();

            var restaurant_people_qty = (from R in context.Restaurant 
                                         where R.RestaurantId == RestaurantId
                                         select R.PeopleQty).First();

            var result = restaurant_people_qty - invoice_people_qty;
            return result;
        }

        public async Task<int> GetTablesAvailablesAsync(int RestaurantId)
        {
            var invoice_table_qty = (from RD in context.ReceiptDetail
                                     where RD.Restaurant.RestaurantId == RestaurantId
                                     select RD.TableNumber).Sum();

            var restaurant_table_qty = (from R in context.Restaurant
                                        where R.RestaurantId == RestaurantId
                                        select R.TableQty).First();

            var result = restaurant_table_qty - invoice_table_qty;
            return result;
        }

        public async Task<int> GetTotalTablesCountAsync(int RestaurantId)
        {
            var result = (from R in context.Restaurant
                          where R.RestaurantId == RestaurantId
                          select R.TableQty).First();
            return result;
        }
    }
}
