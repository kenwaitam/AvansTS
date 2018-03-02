using AvansTS.Core.States.WorkItem;
using System;
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
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Todo to Todo state
		[Fact]
		public void ToDo_To_ToDo()
		{
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InToDo());
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Todo to Doing state
		[Fact]
		public void ToDo_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			Assert.IsType<DoingState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Todo to Done state
		[Fact]
		public void ToDo_To_Done()
		{
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone());
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Doing to ToDo state
		[Fact]
		public void Doing_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			Assert.IsType<DoingState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InToDo());
			Assert.IsType<DoingState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Doing to Doing state
		[Fact]
		public void Doing_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			Assert.IsType<DoingState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress());
			Assert.IsType<DoingState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Doing to Done state
		[Fact]
		public void Doing_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Done to ToDo state
		[Fact]
		public void Done_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InToDo();
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);

		}

		//Test Done to Doing state
		[Fact]
		public void Done_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress());
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}

		//Test Done to Done state
		[Fact]
		public void Done_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState.InProgress());
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].WorkItemState);
		}
	}
}
