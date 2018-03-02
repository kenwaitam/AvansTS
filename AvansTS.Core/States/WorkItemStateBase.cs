using System;

namespace AvansTS.Core.States
{
	public abstract class WorkItemStateBase : IWorkItemState
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
