using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicalProject.Models;

namespace MusicalProject.ViewModels
{
    public class MusicalShowViewModel
    {
        public IEnumerable<MusicalShow> UpcomingShows { get; set; }

        public bool ShowActions { get; set; }

        public ILookup<int, Attendance> Attendances { get; set; }
    }
}