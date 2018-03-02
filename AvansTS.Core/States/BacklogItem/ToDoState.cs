using AvansTS.Core.Components;
using AvansTS.Core.States.Task;

namespace AvansTS.Core.States.BacklogItem
{
	public class ToDoState : WorkItemStateBase
	{
		public WorkItemComponentBase Item { get; set; }

		public override string State { get { return "ToDo"; } }

		public ToDoState(WorkItemComponentBase item)
		{
			Item = item;
		}

		public override void InProgress()
		{
			Item.WorkItemState = Item.DoingState;
		}
	}
}
