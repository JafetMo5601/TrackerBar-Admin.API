using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class Direction
    {
        [Key]
        public int DirectionId { get; set; }
        public string DirectionDescription { get; set; }

        public User User { get; set; }
    }
}
