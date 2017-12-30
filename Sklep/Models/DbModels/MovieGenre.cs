using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.DbModels
{
    public class MovieGenre
    {
        public MovieGenre()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int GenreID { get; set; }

        [Display(Name = "Genre")]
        public MovieGenreType GenreName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}