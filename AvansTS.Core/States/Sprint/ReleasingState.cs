using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint
{
    public class ReleasingState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

		public override string State { get { return "Releasing"; } }

		public ReleasingState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void StartDevelopmentPipeline()
        {
            Sprint.SprintState = Sprint.ReleasedState;
        }
    }
}
