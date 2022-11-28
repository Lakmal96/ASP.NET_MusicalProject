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
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a =>
                a.AttendeeId == userId && a.MusicalShowId == attendanceDto.MusicalShowId);
            if (exists)
            {
                return BadRequest("Already marked as attending");
            };

            var attendance = new Attendance()
            {
                MusicalShowId = attendanceDto.MusicalShowId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
