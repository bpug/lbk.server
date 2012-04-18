using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Lbk.MobileApp.Web.Models
{

    public class GeneratePasswordModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Password")]
        public string Password { get; set; }

       
        [Display(Name = "Hash")]
        public string Hash { get; set; }

        [Display(Name = "Password format")]
        public string Format { get; set; }
    }
   
}
