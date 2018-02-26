using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class Task
    {
		public String Title { get; set; }
		public Developer Developer { get; set; }

		public List<Comment> Comments { get; set; }

		public Boolean IsDone { get; set; }
	}
}
