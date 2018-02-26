using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models.Base
{
    public class WorkItem
    {
		public String Title { get; set; }
		public Developer Developer { get; set; }
		public List<Comment> Comments { get; set; }
		public bool IsDone { get; set; }
	}
}
