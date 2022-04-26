namespace TrackerBar_Admin.API.DataModels
{
    public class YourRestaurantById
    {
        public int id { get; set; }
        public string name { get; set; }
        public int tablesQty { get; set; }
        public int peopleQty { get; set; }
        public int employeeQty { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
