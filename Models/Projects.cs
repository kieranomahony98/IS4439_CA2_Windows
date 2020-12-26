using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class Projects
    { 
        public int ProjectsID { get; set; }
        [Required(ErrorMessage ="Please enter a valid description")]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Please enter a valid title")]

        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "Please enter a valid completion date")]

        public string DateCompleted { get; set; }
        [Required(ErrorMessage = "Please enter a valid resolution")]

        public string Resolution { get; set; }

        public bool isVideo { get; set; }
        public List<ProjectImages> ProjectImages { get; set; }
        public List<ProjectVideos> ProjectVideos { get; set; }

        public List<ProjectComments> ProjectCommentsID { get; set; }
    }
}
