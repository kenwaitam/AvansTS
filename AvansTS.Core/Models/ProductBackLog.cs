using AvansTS.Core.Models.Base;
using System.Collections.Generic;

namespace AvansTS.Core.Models
{
	public class ProductBacklog : BacklogBase
	{
		public List<SprintBacklog> Sprints { get; set; }

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
