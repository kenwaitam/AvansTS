using AvansTS.Core.Components;
using AvansTS.Core.States.Task;

namespace AvansTS.Core.States.BacklogItem
{
	public class DoingState : WorkItemStateBase
	{
		public WorkItemComponentBase Item { get; set; }

		public override string State { get { return "Doing"; } }

		public DoingState(WorkItemComponentBase task)
		{
			Item = task;
		}

		public override void IsDone()
		{
			Item.WorkItemState = Item.DoneState;
		}
	}
}
