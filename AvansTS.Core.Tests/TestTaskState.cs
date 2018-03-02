using AvansTS.Core.Models;
using AvansTS.Core.States.Task;
using System;
using System.Collections.Generic;
using Xunit;

namespace AvansTS.Core.Tests
{
	//Testing the Task State Transitions
	public class TestTaskState : TestDataFixture
	{

		//Constructor that run before each test
		public TestTaskState()
		{
		}

		//Test the first state
		[Fact]
		public void FirstState()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("ToDo", state);
		}

		//Test Todo to Todo state
		[Fact]
		public void ToDo_To_ToDo()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("ToDo", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InToDo());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("ToDo", state);
		}

		//Test Todo to Doing state
		[Fact]
		public void ToDo_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Doing", state);
		}

		//Test Todo to Done state
		[Fact]
		public void ToDo_To_Done()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("ToDo", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("ToDo", state);
		}

		//Test Doing to ToDo state
		[Fact]
		public void Doing_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Doing", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InToDo());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Doing", state);
		}

		//Test Doing to Doing state
		[Fact]
		public void Doing_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Doing", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Doing", state);
		}

		//Test Doing to Done state
		[Fact]
		public void Doing_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Done", state);
		}

		//Test Done to ToDo state
		[Fact]
		public void Done_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Done", state);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InToDo();
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("ToDo", state);

		}

		//Test Done to Doing state
		[Fact]
		public void Done_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Done", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Done", state);
		}

		//Test Done to Done state
		[Fact]
		public void Done_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			var state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Done", state);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress());
			state = prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.State;
			Assert.Equal("Done", state);
		}
	}
}
