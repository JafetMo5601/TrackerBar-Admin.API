using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerBar_Admin.API.DomainModels
{
    public class RestaurantDirection
    {
        public int RestaurantDirectionId { get; set; }
        public string Direction { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
