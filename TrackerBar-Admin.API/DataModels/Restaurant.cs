﻿using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class Restaurant
    {
        // Qty stands for quantity
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int PeopleQty { get; set; }
        public int TableQty { get; set; }
        public int EmployeeQty { get; set; }
        public string Phone { get; set; }
        public User User { get; set; }
        public RestaurantDirection RestaurantDirection { get; set; }
    }
}
