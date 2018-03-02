using AvansTS.Core.Composite;
using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AvansTS.Core.Tests
{
	public class TestSprintState : TestDataFixture
    {
		//Test the first state
		[Fact]
		public void TestFirstState()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			//Assert.False(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test created should able to update
		[Fact]
		public void TestCreatedUpdateable()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			prj.ProductBacklog.Sprints[0].UpdateDate(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
			prj.ProductBacklog.Sprints[0].UpdateName("New");
			prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() });

			Assert.Equal(DateTime.Now.AddDays(1).Date, prj.ProductBacklog.Sprints[0].StartDate.Date);
			Assert.Equal(DateTime.Now.AddDays(2).Date, prj.ProductBacklog.Sprints[0].EndDate.Date);
			Assert.Equal("New", prj.ProductBacklog.Sprints[0].Name);
			Assert.Equal(3, prj.ProductBacklog.Sprints[0].Items.Count);
		}

		//Test started should not able to update
		[Fact]
		public void TestStartedUpdateable()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Started", state);

			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].UpdateDate(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)));
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].UpdateName("New"));
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() }));

			Assert.Equal(DateTime.Now.Date, prj.ProductBacklog.Sprints[0].StartDate.Date);
			Assert.Equal(DateTime.Now.AddDays(5).Date, prj.ProductBacklog.Sprints[0].EndDate.Date);
			Assert.Equal("Sprint Backlog 1", prj.ProductBacklog.Sprints[0].Name);
			Assert.Equal(2, prj.ProductBacklog.Sprints[0].Items.Count);
		}

		//Test finished should not able to update
		[Fact]
		public void TestFinishedUpdateable()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Finished", state);

			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].UpdateDate(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)));
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].UpdateName("New"));
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() }));

			Assert.Equal(DateTime.Now.Date, prj.ProductBacklog.Sprints[0].StartDate.Date);
			Assert.Equal(DateTime.Now.Date, prj.ProductBacklog.Sprints[0].EndDate.Date);
			Assert.Equal("Sprint Backlog 1", prj.ProductBacklog.Sprints[0].Name);
			Assert.Equal(2, prj.ProductBacklog.Sprints[0].Items.Count);
		}

		//Test the created to started
		[Fact]
		public void TestCreatedToStarted()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Started", state);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the created to finished
		[Fact]
		public void TestCreatedToFinished()
		{
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].EndSprint());
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			//Assert.False(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the started to started
		[Fact]
		public void TestStartedToStarted()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].StartSprint());
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Started", state);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the started to finishedBeforeDate
		[Fact]
		public void TestStartedToFinishedBeforeDate()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Started", state);
			prj.ProductBacklog.Sprints[0].EndSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Started", state);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the started to finished on date
		[Fact]
		public void TestStartedToFinishedOnDate()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Started", state);
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now.Date;
			prj.ProductBacklog.Sprints[0].EndSprint();
			state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Finished", state);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the started to finished after date
		[Fact]
		public void TestStartedToFinishedAfterDate()
		{
			//var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			//Assert.Equal("Created", state);
			//// Start Sprints
			//prj.ProductBacklog.Sprints[0].StartSprint();
			//state = prj.ProductBacklog.Sprints[0].SprintState.State;
			//Assert.Equal("Started", state);
			//prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now.AddDays(-1);
			//prj.ProductBacklog.Sprints[0].EndSprint();
			//state = prj.ProductBacklog.Sprints[0].SprintState.State;
			//Assert.Equal("Started", state);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the finished to started
		[Fact]
		public void TestFinishedToStarted()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].StartSprint());
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);

		}

		//Test the finished to finished
		[Fact]
		public void TestFinishedTofinished()
		{
			var state = prj.ProductBacklog.Sprints[0].SprintState.State;
			Assert.Equal("Created", state);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].EndSprint());
		}
	}
}
