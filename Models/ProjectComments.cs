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
        public string CommentText { get; set; }
        public DateTime CommentTimeStamp { get; set; }
   
        public int ProjectID { get; set; }
        public Projects Project { get; set; }
        
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }

}
