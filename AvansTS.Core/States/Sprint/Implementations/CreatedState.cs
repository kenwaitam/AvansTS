using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint.Implementations
{
    public class Created : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public Created(SprintBacklog sprint)
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
            Sprint.SprintState = Sprint.StartedState;
            Sprint.IsCurrent = true;
        }
    }
}
