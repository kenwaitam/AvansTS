using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint
{
    public class CanceledState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public CanceledState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void CloseSprint()
        {
            Sprint.IsCurrent = false;
            Sprint.SprintState = Sprint.ClosedState;
        }
    }
}
