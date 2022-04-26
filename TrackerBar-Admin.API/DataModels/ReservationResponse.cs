namespace TrackerBar_Admin.API.DataModels
{
    public class ReservationResponse
    {
        public int id { get; set; }
        public string owner { get; set; }
        public string details { get; set; }
        public DateTime date { get; set; }
    }
}
