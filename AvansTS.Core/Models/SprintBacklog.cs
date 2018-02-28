using AvansTS.Core.Models.Base;
using AvansTS.Core.States.Sprint;
using AvansTS.Core.States.Sprint.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class SprintBacklog : BacklogBase
    {
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
        public Developer Scrummaster { get; set; }
        public Boolean IsCurrent { get; set; }

        public SprintStateBase SprintState { get; set; }
        public SprintStateBase CreatedState { get; set; }
        public SprintStateBase StartedState { get; set; }
        public SprintStateBase FinishedState { get; set; }

        public SprintBacklog()
        {
            CreatedState = new Created(this);
            StartedState = new Started(this);
            FinishedState = new FinishedState(this);

            SprintState = CreatedState;
        }

        public void AssignScrummaster(Developer user)
        {
            Scrummaster = user;
        }

        public virtual void UpdateName(String name)
        {
            SprintState.UpdateName(name);
        }

        public virtual void UpdateDate(DateTime startDate, DateTime endDate)
        {
            SprintState.UpdateDate(startDate, endDate);
        }

        public virtual void AddItem(ProductBacklogItem item)
        {
            SprintState.AddItem(item);
        }

        public virtual void StartSprint()
        {
            SprintState.StartSprint();
        }

        public virtual void EndSprint()
        {
            SprintState.EndSprint();
        }
    }
}
