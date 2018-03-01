using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task
{
    public abstract class TaskStateBase : ITaskState
    {
		public abstract string State { get; }

        public virtual void InToDo()
        {
            throw new InvalidOperationException();
        }

        public virtual void InProgress()
        {
            throw new InvalidOperationException();
        }

        public virtual void IsDone()
        {
            throw new InvalidOperationException();
        }
    }
}
