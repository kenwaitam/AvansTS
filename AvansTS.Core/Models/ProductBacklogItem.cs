using AvansTS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Models
{
    public class ProductBacklogItem : WorkItem
    {
        public List<Task> Tasks { get; set; }

        public ProductBacklogItem() { }

        public ProductBacklogItem(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void AddDeveloper(Developer usr)
        {
            Developer = usr;

        }
	}
}
