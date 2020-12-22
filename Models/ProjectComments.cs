using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class ProjectComments
    {
        public int ProjectCommentsID { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTimeStamp { get; set; }
        public int ProjectId { get; set; }
        public Projects Project { get; set; }

        public int UserID { get; set; }
        public ApplicationUser applicationUser { get; set; }


    }

}
