using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.DbModels
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<UserAccount>();
        }

        [Key]
        public int RoleID { get; set; }

        [Display(Name = "Role")]
        public RoleType RoleName { get; set; }

        public ICollection<UserAccount> Users { get; set; }
    }
}