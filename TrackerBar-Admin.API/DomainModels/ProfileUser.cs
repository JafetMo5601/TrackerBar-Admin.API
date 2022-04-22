using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DomainModels
{
    public class ProfileUser
    {

        public int Id { get; set; }

        public string? Name { get; set; }
        public int Last { get; set; }
        public int PhoneNumber { get; set; }
         
    }
}
