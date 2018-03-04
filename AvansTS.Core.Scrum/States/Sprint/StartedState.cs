using AvansTS.Core.Models;
using System;

namespace AvansTS.Core.States.Sprint.Implementations
{
    public class StartedState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public override string State { get { return "Started"; } }

        public StartedState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void EndSprint()
        {
            if (Sprint.EndDate <= DateTime.Now)
            {
                Sprint.SprintState = Sprint.FinishedState;
            }
        }
    }
}
