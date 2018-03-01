using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class ToDoState : TaskStateBase
    {
        public Models.Task Task { get; set; }

		public override string State { get { return "ToDo"; } }

		public ToDoState(Models.Task task)
        {
            Task = task;
        }

        public override void InProgress()
        {
            Task.TaskState = Task.DoingState;
        }
    }
}
