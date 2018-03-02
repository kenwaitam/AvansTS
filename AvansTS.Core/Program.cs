using AvansTS.Core.Models;
using AvansTS.Core.Factories;
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
            User pro1 = new User { Name = "Robin", Email = "robin@avans.nl", NotificationOptions = new List<int>() };
            User pro2 = new User { Name = "Jos", Email = "jos@avans.nl", NotificationOptions = new List<int>() };
            User dev1 = new User { Name = "Ritchie", Email = "rebos1@avans.nl", NotificationOptions = new List<int>() };
            User dev2 = new User { Name = "Danny", Email = "kwdtam@avans.nl", NotificationOptions = new List<int>() };

            // Choose Notification Options
            pro1.AddOption(1);
            pro2.AddOption(1);
            dev1.AddOption(1);
            dev2.AddOption(1);
            dev2.AddOption(2);

            // Create New Projects
            Project prj = new Project
            {
                Name = "AvansTS",
                ProductBacklog = new ProductBacklog
                {
                    Name = "Product Backlog",
                    Sprints = new List<SprintBacklog>(),
                    Items = new List<ProductBacklogItem>()
                },
                ProductOwners = new List<User>()
            };

            // Add Product Owners to Project
            prj.AddUser(pro1);
            prj.AddUser(pro2);

            // Create New Sprints
            prj.ProductBacklog.AddSprint(new SprintBacklog(prj)
            {
                Name = "Sprint Backlog 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Items = new List<ProductBacklogItem>()
            });

            // Update Sprints
            prj.ProductBacklog.Sprints[0].UpdateName("23IVK3-Sprint 1");
            prj.ProductBacklog.Sprints[0].UpdateDate(DateTime.Now, DateTime.Now);

            // Add Items
            // to Product Backlog
            prj.ProductBacklog.AddItem(new ProductBacklogItem { Title = "Backlog Item 1", Tasks = new List<WorkItemComponentBase>() });
            // to Sprint Backlog
            prj.ProductBacklog.Sprints[0].AddItem(prj.ProductBacklog.Items[0]);
            prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() });

			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();

            // Add Tasks to Backlog Items
            prj.ProductBacklog.Items[0].Add(new Task(prj.ProductBacklog.Items[0]) { Title = "Task Item 1" });
            prj.ProductBacklog.Sprints[0].Items[0].Add(new Task(prj.ProductBacklog.Sprints[0].Items[0]) { Title = "Task Item 2" });

            // Add Developers or Scrummasters
            // to Sprint Backlog
            prj.ProductBacklog.Sprints[0].AssignScrummaster(dev1);
            // to Backlog Items
            prj.ProductBacklog.Sprints[0].Items[0].AssignDeveloper(dev1);
            // to Tasks
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].AssignDeveloper(dev2);

            // Add Tasks to ToDo, Doing, Done
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InProgress();
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].InProgress();

            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].IsDone();
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();

            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

            // End Sprints
            prj.ProductBacklog.Sprints[0].EndSprint();

            // Review Sprints
            prj.ProductBacklog.Sprints[0].SprintReview();

            // Upload Summaries to Sprint Reviews
            prj.ProductBacklog.Sprints[0].UploadSummary(true);

            // Release, Cancel or Start
            // to Deployments
            prj.ProductBacklog.Sprints[0].DeploymentRelease();
            // to DevOps Pipelines
            prj.ProductBacklog.Sprints[0].StartDevelopmentPipeline();

            // Close Sprints
            prj.ProductBacklog.Sprints[0].CloseSprint();

            // [DEBUGGING: ZONE]
            Debug.WriteLine(prj.ProductBacklog.Sprints[0].SprintState);

			//Debug Backlogitem State transition
			var test = prj.ProductBacklog.Items[0].WorkItemState.State;

			prj.ProductBacklog.Items[0].WorkItemState.InProgress();
			test = prj.ProductBacklog.Items[0].WorkItemState.State;

			prj.ProductBacklog.Items[0].WorkItemState.IsDone();
			test = prj.ProductBacklog.Items[0].WorkItemState.State;

			Debug.WriteLine(test);
		}
    }
}