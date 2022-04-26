using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class RestaurantDirection
    {
        [Key]
        public int RestaurantDirectionId { get; set; }
        public string Direction { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

    }
}
