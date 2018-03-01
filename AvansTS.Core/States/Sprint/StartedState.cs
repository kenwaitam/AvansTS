using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint.Implementations
{
    public class Started : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public Started(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void EndSprint()
        {
            if (Sprint.EndDate == DateTime.Now)
            {
                Sprint.SprintState = Sprint.FinishedState;
                Sprint.IsCurrent = false;
            }
        }
    }
}
