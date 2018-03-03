using AvansTS.Core.Components;

namespace AvansTS.Core.States.WorkItem
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
            Item.NotifyBacklogItem();
            Item.NotifyUser(Item.Sprint.Scrummaster);
        }
    }
}
