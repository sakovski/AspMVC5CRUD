using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Models
{
    public class ViewUserAccount
    {
        [Required(ErrorMessage="First name is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "First Name must have 2-40 letters!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Last Name must have 2-40 letters!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Enter valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Username must have 5-70 letters!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Password must have 5-70 letters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="You need to confirm your password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }     
    }
}