using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Models
{
    public class ProjectImages
    {
        public int ProjectImagesID { get; set; }
        public string imageRoute { get; set; }
        public int ProjectId { get; set; }

        public Projects Project { get; set; }
    }
}
