﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MusicalProject.ViewModels
{
    public class FutureDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "d MMM yyyy", CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}