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
    public class MusicalShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicalShowsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MusicalShowFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MusicalShowFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var musicalShow = new MusicalShow()
            {
                BandId   = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue,
                GenreId = viewModel.Genre
            };

            _context.MusicalShows.Add(musicalShow);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Going()
        {
            var userId = User.Identity.GetUserId();
            var shows = _context.Attendances.Where(a => a.AttendeeId == userId)
                .Select(a => a.MusicalShow).Include(s => s.Band)
                .Include(s => s.Genre).ToList();
            var attendances = _context.Attendances.Where(a => a.AttendeeId == userId)
                .ToList().ToLookup(a => a.MusicalShowId);

            var viewModel = new MusicalShowViewModel()
            {
                UpcomingShows = shows,
                ShowActions = User.Identity.IsAuthenticated,
                Attendances = attendances
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Followings()
        {
            var userId = User.Identity.GetUserId();
            var followings = _context.Followings.Where(f => f.FollowerId == userId)
                .Select(f => f.Subject).ToList();
            

            return View(followings);
        }

    }
}