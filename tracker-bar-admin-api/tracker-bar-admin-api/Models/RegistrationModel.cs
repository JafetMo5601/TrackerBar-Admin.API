using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tracker_bar_admin_api.Models
{
    public record RegistrationModel
    (
        [Required(ErrorMessage = "Name is required!")] string Name,
        [Required(ErrorMessage = "Last name is required!")] string Last,
        [Required(ErrorMessage = "Email is required!")] string Email,
        [Required(ErrorMessage = "Password is required!")] string Password,
        [Required(ErrorMessage = "Confirm password is required!")] string ConfirmPassword,
        [Required(ErrorMessage = "Birth date is required!")] DateTime BirthDate,
        [Required(ErrorMessage = "Role is required!")] string Role
    );
}
