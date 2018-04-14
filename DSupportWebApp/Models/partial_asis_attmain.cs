using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSupportWebApp.Models
{
    public partial class asis_attmain
    {
        [Required]
        [Display(Name ="Kenmerk")]
        public string NameNL { get; set; }

        [Required]
        [Display(Name = "Attribute")]
        public string NameEN { get; set; }

    }
}