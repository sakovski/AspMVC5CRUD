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

        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }
       
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public Role Role { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}