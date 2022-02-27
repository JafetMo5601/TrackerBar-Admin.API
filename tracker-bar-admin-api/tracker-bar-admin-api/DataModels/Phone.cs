using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tracker_bar_admin_api.DataModels
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        //public IList<UserPhone> UserPhones { get; set; }
        public User User { get; set; }
    }
}
