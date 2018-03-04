using AvansTS.Core.Components;
using AvansTS.Core.DevOps.Factories;
using AvansTS.Core.Models;
using AvansTS.Core.SCM.Commands;
using AvansTS.Core.SCM.Models;
using AvansTS.Core.Scrum.Decorators.Page;
using AvansTS.Core.Scrum.Models;
using AvansTS.Core.Scrum.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            User dev1 = new User { Name = "Ritchie", Email = "ritchie@avans.nl", NotificationOptions = new List<int>() };
            User dev2 = new User { Name = "Danny", Email = "danny@avans.nl", NotificationOptions = new List<int>() };
            User dev3 = new User { Name = "Hugo", Email = "hugo@avans.nl", NotificationOptions = new List<int>() };
            User dev4 = new User { Name = "Daniel", Email = "daniel@avans.nl", NotificationOptions = new List<int>() };
            User dev5 = new User { Name = "Marco", Email = "marco@avans.nl", NotificationOptions = new List<int>() };
            User dev6 = new User { Name = "Kevin", Email = "kevin@avans.nl", NotificationOptions = new List<int>() };

            // Choose Notification Options 
            // to Product Owners
            pro1.AddOption(1);
            pro2.AddOption(1);
            // to Developers
            dev1.AddOption(1);
            dev2.AddOption(1);
            dev3.AddOption(1);
            dev4.AddOption(1);
            dev5.AddOption(1);
            dev6.AddOption(1);

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

            // Add Product Owners to Projects
            prj.AddUser(pro1);
            prj.AddUser(pro2);

            // Create New Sprints
            prj.ProductBacklog.AddSprint(new SprintBacklog(prj)
            {
                Name = "Sprint Backlog 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Items = new List<ProductBacklogItem>(),
                Developers = new List<User>()
            });

            // Add Developers to Sprints
            prj.ProductBacklog.Sprints[0].AddDeveloper(dev1);
            prj.ProductBacklog.Sprints[0].AddDeveloper(dev2);
            prj.ProductBacklog.Sprints[0].AddDeveloper(dev3);
            prj.ProductBacklog.Sprints[0].AddDeveloper(dev4);
            prj.ProductBacklog.Sprints[0].AddDeveloper(dev5);
            prj.ProductBacklog.Sprints[0].AddDeveloper(dev6);

            // Update Sprints
            prj.ProductBacklog.Sprints[0].UpdateName("23IVK3-Sprint 1");
            prj.ProductBacklog.Sprints[0].UpdateDate(DateTime.Now, DateTime.Now);

            // Add Items
            // to Product Backlogs
            prj.ProductBacklog.AddItem(new ProductBacklogItem { Title = "Backlog Item 1", Tasks = new List<WorkItemComponentBase>() });
            // to Sprints
            prj.ProductBacklog.Sprints[0].AddItem(prj.ProductBacklog.Items[0]);
            prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() });

            // Start Sprints
            prj.ProductBacklog.Sprints[0].StartSprint();

            // Add Tasks to Backlog Items
            prj.ProductBacklog.Items[0].AddTask(new Task(prj.ProductBacklog.Items[0]) { Title = "Task Item 1" });
            prj.ProductBacklog.Sprints[0].Items[0].AddTask(new Task(prj.ProductBacklog.Sprints[0].Items[0]) { Title = "Task Item 2" });

            // Assign Developers or Scrummasters
            // to Sprints
            prj.ProductBacklog.Sprints[0].AssignScrummaster(dev1);
            // to Backlog Items
            prj.ProductBacklog.Sprints[0].Items[0].AssignDeveloper(dev1);
            // to Tasks
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].AssignDeveloper(dev2);

            // Add Tasks 
            // to Doing 
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InProgress();
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].InProgress();
            // to Done
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].IsDone();
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
            // to ToDo
            prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

            // Subscribe or Unsubscribe to Backlog Items
            prj.ProductBacklog.Sprints[0].Items[0].Unsubscribe(dev3);
            prj.ProductBacklog.Sprints[0].Items[0].Unsubscribe(dev4);
            prj.ProductBacklog.Sprints[0].Items[0].Unsubscribe(dev5);
            prj.ProductBacklog.Sprints[0].Items[0].Unsubscribe(dev6);

            prj.ProductBacklog.Sprints[0].Items[0].Subscribe(dev3);

            // Add Comments to Backlog Items
            prj.ProductBacklog.Sprints[0].Items[0].Thread.AddComment(dev1, "Hey!");
            prj.ProductBacklog.Sprints[0].Items[0].Thread.AddComment(dev2, "Hey! What's Up?");

            // Display Comments
            prj.ProductBacklog.Sprints[0].Items[0].Thread.DisplayComments();

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

            // Create new Reports
            prj.ProductBacklog.Sprints[0].CreateReport(new Report { CompanyName = "Avans", ProjectName = "AvansTS", CompanyLogo = "[Avans Hogeschool]" });

            // Create new Reports Templates
            prj.ProductBacklog.Sprints[0].Report.CreateTemplate(true, true, 2);

            // Write to Reports Pages
            prj.ProductBacklog.Sprints[0].Report.Pages[0].Prev.LeftText = "Test Report 1";
            prj.ProductBacklog.Sprints[0].Report.Pages[1].Prev.LeftText = "Test Report 2";

            // Show Previews of Reports
            prj.ProductBacklog.Sprints[0].Report.Preview();

            // Save Reports
            prj.ProductBacklog.Sprints[0].SaveReport();

            // SCM: Choose Version Control Options to Projects
            prj.ChooseVersionControl();

            // SCM: Create new Branches
            Branch bra1 = new Branch { Name = "develop", Provider = prj.Provider, Commits = new List<Commit>() };

            // SCM: Commit to Local Branches
            dev1.Commit(new Commit { Branch = bra1, Message = "Added SCM" });

            // SCM: Push to Remote Branches
            dev1.Push(bra1);

            // [DEBUGGING: ZONE]
        }
    }
}