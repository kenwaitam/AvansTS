﻿namespace AvansTS.Core.States
{
    public interface IWorkItemState
    {
        void InToDo();
        void InProgress();
        void IsDone();
    }
}
