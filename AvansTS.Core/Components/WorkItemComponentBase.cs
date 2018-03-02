using AvansTS.Core.Models;
using AvansTS.Core.States;
using AvansTS.Core.States.Task;
using AvansTS.Core.Subjects;
using System;

namespace AvansTS.Core.Components
{
	public abstract class WorkItemComponentBase : WorkItemSubjectBase, IWorkItemState
    {
		public String Title { get; set; }
		public User Developer { get; set; }
		public SprintBacklog Sprint { get; set; }

		public WorkItemStateBase WorkItemState { get; set; }
		public WorkItemStateBase ToDoState { get; set; }
		public WorkItemStateBase DoingState { get; set; }
		public WorkItemStateBase DoneState { get; set; }

		public virtual void AssignDeveloper(User user)
		{
			Developer = user;
		}

		public virtual void Add(WorkItemComponentBase component) {
			throw new InvalidOperationException();
		}

        public virtual void Remove(WorkItemComponentBase component)
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
