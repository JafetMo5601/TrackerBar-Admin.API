namespace TrackerBar_Admin.API.DataModels
{
    public class Direction
    {
        public int DirectionId { get; set; }
        public string DirectionDescription { get; set; }
        public User User { get; set; }
    }
}
