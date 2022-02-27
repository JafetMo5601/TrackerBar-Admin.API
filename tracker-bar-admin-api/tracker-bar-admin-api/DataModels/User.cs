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
        // public IList<AdminRestaurante> AdminRestaurantes { get; set; }
        //public IList<UserDirection> Directions { get; set; }
       //public IList<UserPhone> Phones { get; set; }
        public IList<Receipt> Receipts { get; set; }
        public virtual Role Role { get; set; }
    }
}
