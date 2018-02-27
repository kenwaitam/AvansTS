using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models.Base
{
    public class WorkItem
    {
		public String Title { get; set; }
		public Developer Developer { get; set; }
        public Boolean IsDone { get; set; }
        public SprintBacklog Sprint { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
