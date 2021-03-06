﻿using AvansTS.Core.Models;
using System;
using System.Linq;

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

            if (Sprint.Developers != null && Sprint.Developers.Count > 0)
            {
                foreach (var user in Sprint.Developers)
                {
                    item.Subscribe(user);
                }
            }
        }

        public override void StartSprint()
        {
            if (Sprint.Project.ProductBacklog.Sprints.All(s => s.IsCurrent == false))
            {
                Sprint.SprintState = Sprint.StartedState;
                Sprint.IsCurrent = true;
            }
        }
    }
}
