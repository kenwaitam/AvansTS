using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint.Implementations
{
    public class FinishedState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

		public override string State { get { return "Finished"; } }

		public FinishedState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }
    }
}
