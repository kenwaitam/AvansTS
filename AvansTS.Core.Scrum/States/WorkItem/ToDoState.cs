using AvansTS.Core.Components;

namespace AvansTS.Core.States.WorkItem
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
            Item.NotifyBacklogItem();
        }
    }
}
