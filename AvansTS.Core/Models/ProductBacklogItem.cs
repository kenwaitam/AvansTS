using AvansTS.Core.Models.Base;
using AvansTS.Core.Observers;
using AvansTS.Core.States.Task.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AvansTS.Core.Models
{
    public class ProductBacklogItem : WorkItemBase, IObserver
    {
        public Boolean IsDone { get; set; }
        public List<Task> Tasks { get; set; }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void Update()
        {
            if (Tasks.All(t => t.TaskState == t.DoneState))
            {
                IsDone = true;
            }
            else
            {
                IsDone = false;
            }
        }
    }
}
