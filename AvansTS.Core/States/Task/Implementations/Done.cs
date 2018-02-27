using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class Done : TaskStateBase
    {
        public Models.Task Task { get; set; }

        public Done(Models.Task task)
        {
            Task = task;
        }

        public override void InTodo()
        {
            Task.TaskState = Task.ToDo;
            Task.Notify();
        }
    }
}
