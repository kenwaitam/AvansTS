using AvansTS.Core.Models.Base;
using AvansTS.Core.States.Task;
using AvansTS.Core.States.Task.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class Task : WorkItem
    {
        public ProductBacklogItem Item { get; set; }

        public TaskStateBase TaskState { get; set; }
        public TaskStateBase ToDo { get; set; }
        public TaskStateBase Doing { get; set; }
        public TaskStateBase Done { get; set; }

        public Task(ProductBacklogItem item)
        {
            ToDo = new ToDo(this);
            Doing = new Doing(this);
            Done = new Done(this);

            Item = item;
            Sprint = item.Sprint;

            TaskState = ToDo;
        }

        public void AddDeveloper(Developer usr)
        {
            Developer = usr;
            TaskState.InProgress();
        }
    }
}
