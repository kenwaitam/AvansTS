using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AvansTS.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            // SOURCES: http://scrumguide.nl/product-backlog/

            // Create New Accounts
            Developer usr1 = new Developer { Name = "Ritchie" };
            Developer usr2 = new Developer { Name = "Danny" };

            // Create New Projects
            Project prj = new Project
            {
                Name = "AvansTS",
                ProductBacklog = new ProductBacklog
                {
                    Name = "Product Backlog",
                    Sprints = new List<SprintBacklog>(),
                    Items = new List<ProductBacklogItem>()
                }
            };

            // Create New Sprints
            prj.ProductBacklog.AddSprint(new SprintBacklog
            {
                Name = "Sprint Backlog 1",
                StartDate = new DateTime(2018, 2, 26),
                EndDate = new DateTime(2018, 3, 2),
                Scrummaster = usr1,
                Items = new List<ProductBacklogItem>()
            });

            // Add Items
            // to Product Backlog
            prj.ProductBacklog.AddItem(new ProductBacklogItem { Title = "Backlog Item 1", Tasks = new List<Task>() });
            // to Sprint Backlog
            prj.ProductBacklog.Sprints[0].AddItem(prj.ProductBacklog.Items[0]);
            prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<Task>() });

            // Add Tasks to Backlog Items
            prj.ProductBacklog.Items[0].AddTask(new Task(prj.ProductBacklog.Items[0]) { Title = "Task Item 1" });
            prj.ProductBacklog.Sprints[0].Items[0].AddTask(new Task(prj.ProductBacklog.Sprints[0].Items[0]) { Title = "Task Item 2" });

            // Add Developers
            // to Backlog Items
            prj.ProductBacklog.Sprints[0].Items[0].AddDeveloper(usr1);
            // to Tasks
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].AddDeveloper(usr2);


            // [DEBUGGING: ZONE]
            Debug.WriteLine(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState);
        }
    }
}