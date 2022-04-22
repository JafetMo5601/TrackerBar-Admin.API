using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace TrackerBar_Admin.API.DataModels
{
    public class User : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
