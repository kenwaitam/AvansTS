using AvansTS.Core.States.Task;
using AvansTS.Core.Subjects;
using System;

namespace AvansTS.Core.Composite
{
	public abstract class WorkItemComponentBase : WorkItemSubjectBase
    {
		public WorkItemStateBase WorkItemState { get; set; }
		public WorkItemStateBase ToDoState { get; set; }
		public WorkItemStateBase DoingState { get; set; }
		public WorkItemStateBase DoneState { get; set; }

		public WorkItemComponentBase()
		{
			//ToDoState = new ToDoState(this);
			//DoingState = new DoingState(this);
			//DoneState = new DoneState(this);

			//WorkItemState = ToDoState;
		}

		public virtual void Add(WorkItemComponentBase component) {
			throw new InvalidOperationException();
		}

        public void Remove(WorkItemComponentBase component)
		{
			throw new InvalidOperationException();
		}

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
