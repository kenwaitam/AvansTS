using AvansTS.Core.Components;
using AvansTS.Core.Services;
using AvansTS.Core.States;
using AvansTS.Core.States.Task.Implementations;

namespace AvansTS.Core.Models
{
	public class Task : WorkItemComponentBase, IWorkItemState
	{
		public ProductBacklogItem Item { get; set; }

		public Task(ProductBacklogItem item)
		{
			ToDoState = new ToDoState(this);
			DoingState = new DoingState(this);
			DoneState = new DoneState(this);

			Item = item;
			Sprint = item.Sprint;

			WorkItemState = ToDoState;

			AttachToBacklogItem(Item);
			AttachToNotificationService(new NotificationService());
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
