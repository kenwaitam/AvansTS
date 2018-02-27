using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class ToDo : TaskStateBase
    {
        public Models.Task Task { get; set; }

        public ToDo(Models.Task task)
        {
            Task = task;
        }

        public override void InProgress()
        {
            Task.TaskState = Task.Doing;
        }
    }
}
