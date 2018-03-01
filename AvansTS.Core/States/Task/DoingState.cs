using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class DoingState : TaskStateBase
    {
        public Models.Task Task { get; set; }

		public override string State { get { return "Doing"; } }

		public DoingState(Models.Task task)
        {
            Task = task;
        }

        public override void IsDone()
        {
            Task.TaskState = Task.DoneState;
            Task.NotifyBacklogItem();
        }
    }
}
