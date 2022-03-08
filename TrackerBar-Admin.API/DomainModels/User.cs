using Microsoft.AspNetCore.Identity;

namespace TrackerBar_Admin.API.DomainModels
{
    public class User : IdentityUser
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Last { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
