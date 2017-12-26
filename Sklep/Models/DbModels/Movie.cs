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
        public string Title { get; set; }

        public string Description { get; set; }
        
        public MovieGenreType Genre { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public int Minutes { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Director Director { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }
    }
}