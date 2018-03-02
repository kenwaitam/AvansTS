using AvansTS.Core.Components;
using AvansTS.Core.States.Task;

namespace AvansTS.Core.States.BacklogItem
{
	public class DoneState : WorkItemStateBase
	{
		public WorkItemComponentBase Item { get; set; }

		public override string State { get { return "Done"; } }

		public DoneState(WorkItemComponentBase item)
		{
			Item = item;
		}

		public override void InToDo()
		{
			Item.WorkItemState = Item.ToDoState;
		}
	}
}
