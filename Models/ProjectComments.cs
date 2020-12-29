using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class ProjectComments
    {
        public int ProjectCommentsID { get; set; }

        [Required(ErrorMessage = "Please enter a valid comment")]
        [Display(Name ="Comment Text")]
        public string CommentText { get; set; }
        [Display(Name = "Comment Date")]
        public DateTime CommentTimeStamp { get; set; }
        [Required]
        public int ProjectID { get; set; }
        public Projects Project { get; set; }
        [Required]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }

}
