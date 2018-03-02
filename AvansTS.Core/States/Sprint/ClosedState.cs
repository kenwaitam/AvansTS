using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint
{
    public class ClosedState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

		public override string State { get { return "Closed"; } }

		public ClosedState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }
    }
}
