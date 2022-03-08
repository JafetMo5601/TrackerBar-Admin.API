namespace TrackerBar_Admin.API.DomainModels
{
    public class Direction
    {
        public int DirectionId { get; set; }
        public string DirectionDescription { get; set; }
        public User User { get; set; }
    }
}
