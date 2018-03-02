using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States
{
    public interface IWorkItemState
    {
        void InToDo();
        void InProgress();
        void IsDone();
    }
}
