using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvansTS.Core.States.Sprint.Implementations
{
    public class CreatedState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

		public override string State { get { return "Created"; } }

		public CreatedState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void UpdateName(String name)
        {
            Sprint.Name = name;
        }

        public override void UpdateDate(DateTime startDate, DateTime endDate)
        {
            Sprint.StartDate = startDate;
            Sprint.EndDate = endDate;
        }

        public override void AddItem(ProductBacklogItem item)
        {
            Sprint.Items.Add(item);
            item.Sprint = Sprint;
        }

        public override void StartSprint()
        {
            if (Sprint.Project.ProductBacklog.Sprints.All(s => s.IsCurrent == false))
            {
                Sprint.IsCurrent = true;
                Sprint.SprintState = Sprint.StartedState;
            }
        }
    }
}
