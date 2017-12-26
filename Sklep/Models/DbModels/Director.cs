using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.DbModels
{
    public class Director
    {
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int DirectorID { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(40, MinimumLength = 3)]
        public string Nationality { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}