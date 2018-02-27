using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task.Implementations
{
    public class Doing : TaskStateBase
    {
        public Models.Task Task { get; set; }

        public Doing(Models.Task task)
        {
            Task = task;
        }

        public override void IsDone()
        {
            Task.TaskState = Task.Done;
            Task.Notify();
        }
    }
}
