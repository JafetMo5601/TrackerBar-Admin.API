using System.Collections.Generic;


namespace tracker_bar_admin_api.DataModels
{
    public class Direction
    {
        public int DirectionId { get; set; }
        public string DirectionDescription { get; set; }
        public IList<UserDirection> UserDirections { get; set; }

    }
}
