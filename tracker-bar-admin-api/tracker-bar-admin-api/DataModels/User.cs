using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace tracker_bar_admin_api.DataModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set;  }
        public Role Role { get; set; }
    }
}
