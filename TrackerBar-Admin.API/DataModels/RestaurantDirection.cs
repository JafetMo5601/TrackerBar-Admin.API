﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerBar_Admin.API.DataModels
{
    public class RestaurantDirection
    {
        [ForeignKey("Restaurant")]
        public int RestaurantDirectionId { get; set; }
        public string Direction { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}