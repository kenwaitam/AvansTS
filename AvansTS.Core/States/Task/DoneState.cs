using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class Done : TaskStateBase
    {
        public Models.Task Task { get; set; }

		public override string State { get { return "Done"; } }

		public Done(Models.Task task)
        {
            Task = task;
        }

        public override void InTodo()
        {
            Task.TaskState = Task.ToDoState;
            Task.NotifyBacklogItem();
            Task.NotifyScrummaster(Task.Sprint.Scrummaster);
        }
    }
}
