using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicalProject.Models
{
    public class MusicalShow
    {
        public int Id { get; set; }

        public ApplicationUser Band { get; set; }

        [Required]
        public string BandId { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}