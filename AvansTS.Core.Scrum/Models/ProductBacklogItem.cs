using AvansTS.Core.Components;
using AvansTS.Core.Observers;
using AvansTS.Core.Services;
using AvansTS.Core.States;
using AvansTS.Core.States.WorkItem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvansTS.Core.Models
{
    public class ProductBacklogItem : WorkItemComponentBase, IBacklogItemObserver
    {
        public DiscussionThread Thread { get; set; }
        public List<WorkItemComponentBase> Tasks { get; set; }

        public ProductBacklogItem()
        {
            Thread = new DiscussionThread(this) { Comments = new List<Comment>() };

            ToDoState = new ToDoState(this);
            DoingState = new DoingState(this);
            DoneState = new DoneState(this);

            WorkItemState = ToDoState;

            AttachToNotificationService(new NotificationService());
        }

        public override void AddTask(WorkItemComponentBase task)
        {
            Tasks.Add(task);
        }

        public void Update()
        {
            if (Tasks.Any(t => t.WorkItemState == t.ToDoState))
            {
                WorkItemState = ToDoState;
            }

            if (Tasks.Any(t => t.WorkItemState == t.DoingState))
            {
                WorkItemState = DoingState;
            }

            if (Tasks.All(t => t.WorkItemState == t.DoneState))
            {
                WorkItemState = DoneState;
            }
        }
    }
}
