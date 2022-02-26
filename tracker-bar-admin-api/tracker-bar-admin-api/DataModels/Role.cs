using System.ComponentModel.DataAnnotations.Schema;


namespace tracker_bar_admin_api.DataModels
{
    public class Role
    {
        [ForeignKey("User")]
        public int RoleId { get; set; }
        public int RoleDescription { get; set; }
        public virtual User User { get; set; }
    }
}
