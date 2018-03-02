using AvansTS.Core.Components;

namespace AvansTS.Core.States.Task.Implementations
{
	public class DoneState : WorkItemStateBase
    {
        public WorkItemComponentBase Task { get; set; }

		public override string State { get { return "Done"; } }

		public DoneState(WorkItemComponentBase task)
        {
            Task = task;
        }

        public override void InToDo()
        {
            Task.NotifyBacklogItem();
            Task.NotifyScrummaster(Task.Sprint.Scrummaster);
            Task.WorkItemState = Task.ToDoState;
        }
    }
}
