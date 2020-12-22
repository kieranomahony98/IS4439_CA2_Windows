using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class Projects
    { 
        public int ProjectsID { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectTitle { get; set; }
        public string DateCompleted { get; set; }
        public string Resolution { get; set; }

        public bool isVideo { get; set; }
        public List<ProjectImages> ProjectImages { get; set; }
        public List<ProjectVideos> ProjectVideos { get; set; }

        public List<ProjectComments> ProjectCommentsID { get; set; }
    }
}
