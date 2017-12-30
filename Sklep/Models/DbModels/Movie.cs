using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models.DbModels
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name must have 2-100 letters!")]
        public string Title { get; set; }

        [StringLength(300, ErrorMessage = "Maximum length of description is 300 letters!")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Please enter the country!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Country must have 3-50 letters!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter the language!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Language must have 3-50 letters!")]
        public string Language { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid amount of minutes!")]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Please enter the year of production!")]
        [Range(1888, 3000, ErrorMessage = "Please enter valid year!")] 
        public int Year { get; set; }

        public virtual MovieGenre Genre { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public virtual Director Director { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }
    }
}