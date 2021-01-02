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
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Please have the title within 10 and 500 characters")]

        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Please enter a valid title")]
        [Display(Name = "Project Title")]
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Please have the title within 5 and 100 characters")]
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

        public string Dir { get; set; }
        public List<ProjectImages> ProjectImages { get; set; }

        public List<ProjectComments> ProjectCommentsID { get; set; }
    }
}
