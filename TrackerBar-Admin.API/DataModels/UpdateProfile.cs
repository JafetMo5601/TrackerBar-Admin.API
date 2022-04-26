namespace TrackerBar_Admin.API.DataModels
{
    public class UpdateProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Last { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
