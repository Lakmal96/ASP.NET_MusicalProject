using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicalProject.Models
{
    public class Attendance
    {
        public ApplicationUser Attendee { get; set; }

        public MusicalShow MusicalShow { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MusicalShowId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}