namespace TrackerBar_Admin.API.DataModels
{
    public class Reservations
    {
        public int TableNumber { get; set; }
        public int PeopleQty{ get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public DateTime boughtAt { get; set; }

    }
}
