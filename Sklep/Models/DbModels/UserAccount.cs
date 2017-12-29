using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models.DbModels
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "First Name must have 2-40 letters!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Last Name must have 2-40 letters!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Enter valid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Last Name must have 5-70 letters!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Password must have 5-70 letters!")]
        public string Password { get; set; }

        public virtual Role Role { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}