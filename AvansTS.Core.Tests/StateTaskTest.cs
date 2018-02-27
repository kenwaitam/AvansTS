using AvansTS.Core.Models;
using AvansTS.Core.States.Task;
using System;
using System.Collections.Generic;
using Xunit;

namespace AvansTS.Core.Tests
{
	//Testing the Task State Transitions
	public class TaskStateTest
	{
		// Create New Developers
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

		//Constructor that run before each test
		public TaskStateTest()
		{
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
		}

		//Test the first state
		[Fact]
		public void FirstState()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("ToDo", state);
		}

		//Test Todo to Todo state
		[Fact]
		public void ToDo_To_ToDo()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("ToDo", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsWrong());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("ToDo", state);
		}

		//Test Todo to Doing state
		[Fact]
		public void ToDo_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Doing", state);
		}

		//Test Todo to Done state
		[Fact]
		public void ToDo_To_Done()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("ToDo", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsDone());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("ToDo", state);
		}

		//Test Doing to ToDo state
		[Fact]
		public void Doing_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Doing", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsWrong());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Doing", state);
		}

		//Test Doing to Doing state
		[Fact]
		public void Doing_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Doing", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Doing", state);
		}

		//Test Doing to Done state
		[Fact]
		public void Doing_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Done", state);
		}

		//Test Done to ToDo state
		[Fact]
		public void Done_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Done", state);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsWrong();
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("ToDo", state);

		}

		//Test Done to Doing state
		[Fact]
		public void Done_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Done", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Done", state);
		}

		//Test Done to Done state
		[Fact]
		public void Done_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Done", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.InProgress());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].TaskState.State;
			Assert.Equal("Done", state);
		}
	}
}
