using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint
{
    public class ReleasedState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public ReleasedState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void CloseSprint()
        {
            Sprint.SprintState = Sprint.ClosedState;
        }
    }
}
