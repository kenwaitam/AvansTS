using AvansTS.Core.States.SprintBlacklog;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class SprintBacklog
    {
		public String Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
        public Developer Scrummaster { get; set; }
        public List<ProductBacklogItem> Items { get; set; }

		public Boolean IsCurrent { get; set; }
        public SprintStateBase State { get; set; }

        public void StartSprint()
        {
            IsCurrent = true;
        }

        public void AddItem(ProductBacklogItem item)
        {
            Items.Add(item);
            item.Sprint = this;
        }
	}
}
