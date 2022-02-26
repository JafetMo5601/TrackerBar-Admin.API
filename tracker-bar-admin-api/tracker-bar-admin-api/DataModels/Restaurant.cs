using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace tracker_bar_admin_api.DataModels
{ 
    public class Restaurant
    {
        // Qty stands for quantity
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int PeopleQty { get; set; }
        public int TableQty { get; set; }
        public int EmployeeQty { get; set; }
        public string Phone { get; set; }
        public IList<AdminRestaurante> AdminRestaurantes { get; set; }
       public virtual RestaurantDirection Direction { get; set; }
    }
}
