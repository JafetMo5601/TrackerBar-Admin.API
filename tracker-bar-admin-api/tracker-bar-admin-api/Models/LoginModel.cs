using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tracker_bar_admin_api.Models
{
    public record LoginModel
    (
        [Required(ErrorMessage = "Email is required!")] string Email,
        [Required(ErrorMessage = "Password is required!")] string Password
    );
}
