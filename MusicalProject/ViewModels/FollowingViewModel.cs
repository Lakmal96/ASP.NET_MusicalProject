using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicalProject.Models;

namespace MusicalProject.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Subjects { get; set; }

        public TYPE Type { get; set; }
    }
}