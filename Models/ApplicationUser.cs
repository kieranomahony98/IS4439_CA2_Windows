using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required(ErrorMessage ="Please enter your full name")]

        public string FullName { get; set; }
        [Required(ErrorMessage ="Please enter your current occupation")]

        public string Occupation { get; set; }

       
        public bool IsAdmin { get; set; }

        public List<ProjectComments> projectComments { get; set; }
    }
}
