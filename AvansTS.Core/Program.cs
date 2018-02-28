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
            // SOURCE (Scrum Guidance): http://scrumguide.nl/product-backlog/
            // SOURCE (UML Guidance):   https://stackoverflow.com/questions/12604031/c-sharp-code-for-association-aggregation-composition

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
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Items = new List<ProductBacklogItem>()
            });

            // Update Sprints
            prj.ProductBacklog.Sprints[0].UpdateName("23IVK3-Sprint 1");

            // Add Items
            // to Product Backlog
            prj.ProductBacklog.AddItem(new ProductBacklogItem { Title = "Backlog Item 1", Tasks = new List<Task>() });
            // to Sprint Backlog
            prj.ProductBacklog.Sprints[0].AddItem(prj.ProductBacklog.Items[0]);
            prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<Task>() });

            // Start Sprints
            prj.ProductBacklog.Sprints[0].StartSprint();

            // Add Tasks to Backlog Items
            prj.ProductBacklog.Items[0].AddTask(new Task(prj.ProductBacklog.Items[0]) { Title = "Task Item 1" });
            prj.ProductBacklog.Sprints[0].Items[0].AddTask(new Task(prj.ProductBacklog.Sprints[0].Items[0]) { Title = "Task Item 2" });

            // Add Developers or Scrummasters
            // to Sprint Backlog
            prj.ProductBacklog.Sprints[0].AssignScrummaster(usr1);
            // to Backlog Items
            prj.ProductBacklog.Sprints[0].Items[0].AssignDeveloper(usr1);
            // to Tasks
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].AssignDeveloper(usr2);

            // Add Tasks to ToDo, Doing, Done
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InProgress();
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].InProgress();

            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].IsDone();
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();

            //prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

            // [DEBUGGING: ZONE]
            Debug.WriteLine(prj.ProductBacklog.Sprints[0].Items[0].IsDone);
        }
    }
}