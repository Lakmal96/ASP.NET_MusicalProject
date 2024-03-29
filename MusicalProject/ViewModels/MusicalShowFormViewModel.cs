﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MusicalProject.Models;

namespace MusicalProject.ViewModels
{
    public class MusicalShowFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDateValidation]
        public string Date { get; set; }

        [Required]
        [TimeValidation]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title { get; set; }

        public string Action
        {
            get
            {
                return Id != 0 ? "Update" : "Create";
            }

        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}