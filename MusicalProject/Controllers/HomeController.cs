using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicalProject.Models;
using MusicalProject.ViewModels;

namespace MusicalProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingShows = _context.MusicalShows
                .Include(s => s.Band)
                .Include(s => s.Genre)
                .Where(s => s.DateTime > DateTime.Now);

            string userId = User.Identity.GetUserId();
            var attendances = _context.Attendances.Where(a => a.AttendeeId == userId)
                .ToList().ToLookup(a => a.MusicalShowId);

            var viewModel = new MusicalShowViewModel()
            {
                UpcomingShows = upcomingShows,
                ShowActions = User.Identity.IsAuthenticated,
                Attendances = attendances
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}