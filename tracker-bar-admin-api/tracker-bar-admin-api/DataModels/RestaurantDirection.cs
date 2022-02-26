using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tracker_bar_admin_api.DataModels
{
    public class RestaurantDirection
    {
        [ForeignKey("Restaurant")]
        public int RestaurantDirectionId { get; set; }
        public string Direction { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
