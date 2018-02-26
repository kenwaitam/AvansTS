using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class SprintBacklog
    {
		public String Title { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndtDate { get; set; }
		public ProductBacklog ProductBacklog { get; set; }

	}
}
