using AvansTS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class ProductBacklogItem : WorkItem
    {
		public List<Task> Tasks { get; set; }
	}
}
