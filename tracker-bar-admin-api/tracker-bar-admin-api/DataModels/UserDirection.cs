namespace tracker_bar_admin_api.DataModels
{
    public class UserDirection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DirectionId { get; set; }
        public Direction Direction { get; set; }
    }
}
