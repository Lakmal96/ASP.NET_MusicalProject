﻿using System;
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
                Genres = _context.Genres.ToList(),
                Title = "Add a Show"
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
                GenreId = viewModel.Genre,
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

        [Authorize]
        public ActionResult MyShows()
        {
            var userId = User.Identity.GetUserId();
            var myShows = _context.MusicalShows
                .Where(m => m.BandId == userId && m.DateTime > DateTime.Now && !m.IsCancelled).ToList();

            return View(myShows);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var show = _context.MusicalShows.Single(s => s.Id == id && s.BandId == userId);

            var viewModel = new MusicalShowFormViewModel()
            {
                Id = show.Id,
                Genres = _context.Genres.ToList(),
                Venue = show.Venue,
                Date = show.DateTime.ToString("d MMM yyyy"),
                Time = show.DateTime.ToString("HH:mm"),
                Genre = show.GenreId,
                Title = "Edit a Show"
            };

            return View("Create", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MusicalShowFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var showDb = _context.MusicalShows.Single(s => s.Id == viewModel.Id && s.BandId == userId);
            
            showDb.DateTime = viewModel.GetDateTime();
            showDb.Venue = viewModel.Venue;
            showDb.GenreId = viewModel.Genre;
            

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}