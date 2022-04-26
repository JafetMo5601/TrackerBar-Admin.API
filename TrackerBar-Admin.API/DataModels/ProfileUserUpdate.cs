using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class ProfileUserUpdate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite Nombre")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Digite Apellido")]
        public int Last { get; set; }
        [Required(ErrorMessage = "Digite numero de telefono")]
        public int PhoneNumber { get; set; }
    }
}
