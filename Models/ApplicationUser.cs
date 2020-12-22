using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string fullName { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }

        public string Occupation { get; set; }

        public bool IsAdmin { get; set; }

        public List<ProjectComments> projectComments { get; set; }
    }
}
