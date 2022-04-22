using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }

        public User User { get; set; }
    }
}
