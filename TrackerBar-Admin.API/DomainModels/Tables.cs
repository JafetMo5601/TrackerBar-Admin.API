using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DomainModels
{
    public class Tables
    {

        public String? Name { get; set; }

        public String? LastName { get; set; }

        public int TableNumber { get; set; }
        public int PeopleQTY { get; set; }
        public string? Date { get; set; }    


    }
}
