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
        [Display(Name ="Project Description")]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Please enter a valid title")]
        [Display(Name = "Project Title")]

        public string ProjectTitle { get; set; }
        
        [Required(ErrorMessage = "Please enter a valid completion date")]
        [Display(Name = "Date Completed")]
        public string DateCompleted { get; set; }

        [Required(ErrorMessage = "Please enter a valid resolution")]
        [Display(Name = "Project Resolution")]
        public string Resolution { get; set; }
        [Required]
        [Display(Name = "Check if video")]

        public bool isVideo { get; set; }

        public List<ProjectImages> ProjectImages { get; set; }

        public List<ProjectComments> ProjectCommentsID { get; set; }
    }
}
