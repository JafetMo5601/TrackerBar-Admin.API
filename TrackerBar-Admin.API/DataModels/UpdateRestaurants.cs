using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class UpdateRestaurants
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "People quantity is required")]
        public int PeopleQty { get; set; }

        [Required(ErrorMessage = "Tables quantity is required")]
        public int TableQty { get; set; }

        [Required(ErrorMessage = "Employees quantity is required")]
        public int EmployeeQty { get; set; }
        public string Phone { get; set; }
        public int User { get; set; }
        public string Direction { get; set; }
    }
}
