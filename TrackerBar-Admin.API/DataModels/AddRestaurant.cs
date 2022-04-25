namespace TrackerBar_Admin.API.DataModels
{
    public class AddRestaurant
    {
        public string RestaurantName { get; set; }
        public int PeopleQty { get; set; }
        public int TableQty { get; set; }
        public int EmployeeQty { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public string UserId { get; set; }
    }
}
