using AvansTS.Core.Components;
using AvansTS.Core.Models;
using System;
using System.Collections.Generic;

namespace AvansTS.Core.Tests
{
	public class TestDataFixture
	{
		// Create New Accounts
		public User pro1 = new User { Name = "Robin", Email = "robin@avans.nl", NotificationOptions = new List<int>() };
		public User pro2 = new User { Name = "Jos", Email = "jos@avans.nl", NotificationOptions = new List<int>() };
		public User dev1 = new User { Name = "Ritchie", Email = "rebos1@avans.nl", NotificationOptions = new List<int>() };
		public User dev2 = new User { Name = "Danny", Email = "kwdtam@avans.nl", NotificationOptions = new List<int>() };

		// Create New Projects
		public Project prj = new Project
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


		//Constructor that run before each test
		public TestDataFixture()
		{
			// Choose Notification Options
			pro1.AddOption(1);
			pro2.AddOption(1);
			dev1.AddOption(1);
			dev2.AddOption(2);

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

			// Add Items
			// to Product Backlog
			prj.ProductBacklog.AddItem(new ProductBacklogItem { Title = "Backlog Item 1", Tasks = new List<WorkItemComponentBase>() });
			// to Sprint Backlog
			prj.ProductBacklog.Sprints[0].AddItem(prj.ProductBacklog.Items[0]);
			prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() });

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
		}
	}
}
