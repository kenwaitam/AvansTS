using AvansTS.Core.Composite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class ToDoState : WorkItemStateBase
    {
        public WorkItemComponentBase Task { get; set; }

		public override string State { get { return "ToDo"; } }

		public ToDoState(WorkItemComponentBase task)
        {
            Task = task;
        }

        public override void InProgress()
        {
            Task.WorkItemState = Task.DoingState;
        }
    }
}
