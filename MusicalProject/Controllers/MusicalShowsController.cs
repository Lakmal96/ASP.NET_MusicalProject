using System;
using System.Collections.Generic;
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

    }
}