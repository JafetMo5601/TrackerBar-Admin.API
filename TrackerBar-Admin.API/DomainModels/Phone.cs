namespace TrackerBar_Admin.API.DomainModels
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
    }
}
