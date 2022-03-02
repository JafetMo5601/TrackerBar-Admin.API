using System.ComponentModel.DataAnnotations.Schema;


namespace tracker_bar_admin_api.DataModels
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
    }
}
