using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Task
{
    public abstract class TaskStateBase
    {
        public virtual void InProgress()
        {
            throw new InvalidOperationException();
        }

        public virtual void IsDone()
        {
            throw new InvalidOperationException();
        }

        public virtual void IsWrong()
        {
            throw new InvalidOperationException();
        }
    }
}
