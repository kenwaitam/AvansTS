using AvansTS.Core.Observers;
using AvansTS.Core.Services;
using AvansTS.Core.States;
using AvansTS.Core.States.Task;
using AvansTS.Core.States.Task.Implementations;
using AvansTS.Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class Task : TaskSubjectBase, ITaskState
    {
        public ProductBacklogItem Item { get; set; }

        public TaskStateBase TaskState { get; set; }
        public TaskStateBase ToDoState { get; set; }
        public TaskStateBase DoingState { get; set; }
        public TaskStateBase DoneState { get; set; }

        public Task(ProductBacklogItem item)
        {
            ToDoState = new ToDoState(this);
            DoingState = new DoingState(this);
            DoneState = new Done(this);

            Item = item;
            Sprint = item.Sprint;

            TaskState = ToDoState;

            AttachToBacklogItem(Item);
            AttachToNotificationService(new NotificationService());
        }

        public void InToDo()
        {
            TaskState.InToDo();
        }

        public void InProgress()
        {
            TaskState.InProgress();
        }

        public void IsDone()
        {
            TaskState.IsDone();
        }
    }
}
