using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class ProductBacklog
    {
        public String Name { get; set; }
        public List<SprintBacklog> Sprints { get; set; }
		public List<ProductBacklogItem> Items { get; set; }

        public void AddSprint(SprintBacklog sprint)
        {
            Sprints.Add(sprint);
        }

		public void AddItem(ProductBacklogItem item)
		{
			Items.Add(item);
		}
    }
}
