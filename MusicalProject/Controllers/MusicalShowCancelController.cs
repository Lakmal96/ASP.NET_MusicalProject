using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicalProject.Models;

namespace MusicalProject.Controllers
{
    [Authorize]
    public class MusicalShowCancelController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MusicalShowCancelController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId(); 
            var showDb = _context.MusicalShows.Single(s => s.Id == id && s.BandId == userId);
            showDb.IsCancelled = true;
            _context.SaveChanges();

            return Ok();
        }

    }
}
