using AvansTS.Core.Components;

namespace AvansTS.Core.States.WorkItem
{
    public class DoingState : WorkItemStateBase
    {
        public WorkItemComponentBase Item { get; set; }

        public override string State { get { return "Doing"; } }

        public DoingState(WorkItemComponentBase item)
        {
            Item = item;
        }

        public override void IsDone()
        {
            Item.WorkItemState = Item.DoneState;
            Item.NotifyBacklogItem();
        }
    }
}
