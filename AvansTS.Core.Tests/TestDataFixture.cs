using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Tests
{
    public class TestDataFixture
    {
		// Create New Accounts
		public Developer usr1 = new Developer { Name = "Ritchie", Email = "rebos1@avans.nl", NotificationOptions = new List<int>() };
		public Developer usr2 = new Developer { Name = "Danny", Email = "kwdtam@avans.nl", NotificationOptions = new List<int>() };

		// Create New Projects
		public Project prj = new Project
		{
			Name = "AvansTS",
			ProductBacklog = new ProductBacklog
			{
				Name = "Product Backlog",
				Sprints = new List<SprintBacklog>(),
				Items = new List<ProductBacklogItem>()
			}
		};

		//Constructor that run before each test
		public TestDataFixture()
		{
			// Choose Notification Options
			usr1.AddOption(1);
			usr2.AddOption(2);

			// Create New Sprints
			prj.ProductBacklog.AddSprint(new SprintBacklog
			{
				Name = "Sprint Backlog 1",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddDays(5),
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
			prj.ProductBacklog.Sprints[0].Items[0].AssignDeveloper(usr1);
			//to Sprint
			prj.ProductBacklog.Sprints[0].AssignScrummaster(usr1);
			// to Tasks
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].AssignDeveloper(usr2);
		}
	}
}
