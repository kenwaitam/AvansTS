using AvansTS.Core.States.SprintBlacklog;
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
		public bool IsStarting { get; set; }
		public Developer Scrummaster { get; set; }

		public SprintStateBase State { get; set; }

		public void StartSprint()
		{
			IsStarting = true;
		}
	}
}
