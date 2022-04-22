namespace TrackerBar_Admin.API.DataModels
{
    public class DeleteRestaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int PeopleQty { get; set; }
        public int TableQty { get; set; }
        public int EmployeeQty { get; set; }
        public string Phone { get; set; }
        public int User { get; set; }
        public string Direction { get; set; }
    }
}
