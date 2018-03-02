using AvansTS.Core.Components;

namespace AvansTS.Core.States.Task.Implementations
{
	public class DoingState : WorkItemStateBase
    {
        public WorkItemComponentBase Task { get; set; }

		public override string State { get { return "Doing"; } }

		public DoingState(WorkItemComponentBase task)
        {
            Task = task;
        }

        public override void IsDone()
        {
            Task.NotifyBacklogItem();
            Task.WorkItemState = Task.DoneState;
        }
    }
}
