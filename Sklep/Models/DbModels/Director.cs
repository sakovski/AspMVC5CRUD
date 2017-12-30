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

        [Required(ErrorMessage = "First Name is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "First Name must have 2-40 letters!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Last Name must have 2-40 letters!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nationality must have 2-100 letters!")]
        public string Nationality { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Enter valid date (YYYY-MM-DD)")]
        [Display(Name = "Date of birth (YYYY-MM-DD)")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}