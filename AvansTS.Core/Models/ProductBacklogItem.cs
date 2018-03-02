using AvansTS.Core.Composite;
using AvansTS.Core.Observers;
using AvansTS.Core.States;
using AvansTS.Core.States.BacklogItem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvansTS.Core.Models
{
	public class ProductBacklogItem : WorkItemComponentBase, IBacklogItemObserver, IWorkItemState
    {
        public DiscussionThread Thread { get; set; }
        public Boolean Done { get; set; }
        public List<WorkItemComponentBase> Tasks { get; set; }

		public ProductBacklogItem()
		{
			ToDoState = new ToDoState(this);
			DoingState = new DoingState(this);
			DoneState = new DoneState(this);

			WorkItemState = ToDoState;
		}

		//Add Task
        public override void Add(WorkItemComponentBase task)
        {
            Tasks.Add(task);
        }

        public void Update()
        {
            if (Tasks.All(t => t.WorkItemState == t.DoneState))
            {
                Done = true;
            }
            else
            {
                Done = false;
            }
        }

		public override void InToDo()
		{
			WorkItemState.InToDo();
		}

		public override void InProgress()
		{
			WorkItemState.InProgress();
		}

		public override void IsDone()
		{
			WorkItemState.IsDone();
		}
	}
}
