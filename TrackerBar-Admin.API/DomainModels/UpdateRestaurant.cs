﻿namespace TrackerBar_Admin.API.DomainModels
{
    public class UpdateRestaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int PeopleQty { get; set; }
        public int TableQty { get; set; }
        public int EmployeeQty { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }

        public string Direccion { get; set; }
    }
}
