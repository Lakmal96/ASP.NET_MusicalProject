using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicalProject.Dtos;
using MusicalProject.Models;

namespace MusicalProject.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Followings.Any(f =>
                f.SubjectId == userId && f.SubjectId == followingDto.SubjectId);
            if (exists)
            {
                return BadRequest("Already following");
            };
            var following = new Following()
            {
                SubjectId = followingDto.SubjectId,
                FollowerId = userId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
