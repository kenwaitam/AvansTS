using AvansTS.Core.Components;
using AvansTS.Core.Models;
using AvansTS.Core.States.Sprint;
using AvansTS.Core.States.Sprint.Implementations;
using System;
using System.Collections.Generic;
using Xunit;

namespace AvansTS.Core.Tests
{
	public class TestSprintState : TestDataFixture
	{
		//Test the first state
		[Fact]
		public void TestFirstState()
		{
			//Assert.False(prj.ProductBacklog.Sprints[0].IsCurrent);
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test created should able to update
		[Fact]
		public void TestCreatedUpdateable()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			prj.ProductBacklog.Sprints[0].UpdateDate(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
			prj.ProductBacklog.Sprints[0].UpdateName("New");
			prj.ProductBacklog.Sprints[0].AddItem(new ProductBacklogItem { Title = "Backlog Item 2", Tasks = new List<WorkItemComponentBase>() });

			Assert.Equal(DateTime.Now.AddDays(1).Date, prj.ProductBacklog.Sprints[0].StartDate.Date);
			Assert.Equal(DateTime.Now.AddDays(2).Date, prj.ProductBacklog.Sprints[0].EndDate.Date);
			Assert.Equal("New", prj.ProductBacklog.Sprints[0].Name);
			Assert.Equal(3, prj.ProductBacklog.Sprints[0].Items.Count);
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test started should not able to update
		[Fact]
		public void TestStartedUpdateable()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);

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
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test finished should not able to update
		[Fact]
		public void TestFinishedUpdateable()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			Assert.IsType<FinishedState>(prj.ProductBacklog.Sprints[0].SprintState);

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
			Assert.IsType<FinishedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the created to started
		[Fact]
		public void TestCreatedToStarted()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the created to finished
		[Fact]
		public void TestCreatedToFinished()
		{
			Assert.Throws<InvalidOperationException>(() =>
			prj.ProductBacklog.Sprints[0].EndSprint());
			//Assert.False(prj.ProductBacklog.Sprints[0].IsCurrent);
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the started to started
		[Fact]
		public void TestStartedToStarted()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].StartSprint());
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the started to finishedBeforeDate
		[Fact]
		public void TestStartedToFinishedBeforeDate()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
			prj.ProductBacklog.Sprints[0].EndSprint();
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the started to finished on date
		[Fact]
		public void TestStartedToFinishedOnDate()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now.Date;
			prj.ProductBacklog.Sprints[0].EndSprint();
			Assert.IsType<FinishedState>(prj.ProductBacklog.Sprints[0].SprintState);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the started to finished after date
		[Fact]
		public void TestStartedToFinishedAfterDate()
		{
			//Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			//// Start Sprints
			//prj.ProductBacklog.Sprints[0].StartSprint();
			//Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
			//prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now.AddDays(-1);
			//prj.ProductBacklog.Sprints[0].EndSprint();
			//Assert.IsType<StartedState>(prj.ProductBacklog.Sprints[0].SprintState);
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
		}

		//Test the finished to started
		[Fact]
		public void TestFinishedToStarted()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].StartSprint());
			//Assert.True(prj.ProductBacklog.Sprints[0].IsCurrent);
			Assert.IsType<FinishedState>(prj.ProductBacklog.Sprints[0].SprintState);

		}

		//Test the finished to finished
		[Fact]
		public void TestFinishedTofinished()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			Assert.Throws<InvalidOperationException>(() =>
				prj.ProductBacklog.Sprints[0].EndSprint());
			Assert.IsType<FinishedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the finished to reveiw
		[Fact]
		public void TestFinishedToReview()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			prj.ProductBacklog.Sprints[0].SprintReview();
			Assert.IsType<ReviewState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the finished to release
		[Fact]
		public void TestFinishedToRelease()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			prj.ProductBacklog.Sprints[0].DeploymentRelease();
			Assert.IsType<ReleasingState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the reveiw to release
		[Fact]
		public void TestReveiwToRelease()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			prj.ProductBacklog.Sprints[0].SprintReview();
			prj.ProductBacklog.Sprints[0].UploadSummary(true);
			prj.ProductBacklog.Sprints[0].DeploymentRelease();
			Assert.IsType<ReleasingState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the reveiw to canceled
		[Fact]
		public void TestReveiwToCanceled()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			prj.ProductBacklog.Sprints[0].SprintReview();
			prj.ProductBacklog.Sprints[0].UploadSummary(true);
			prj.ProductBacklog.Sprints[0].DeploymentCanceled();
			Assert.IsType<CanceledState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the cancel to closed
		[Fact]
		public void TestCanceledToClosed()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			prj.ProductBacklog.Sprints[0].SprintReview();
			prj.ProductBacklog.Sprints[0].UploadSummary(true);
			prj.ProductBacklog.Sprints[0].DeploymentCanceled();
			prj.ProductBacklog.Sprints[0].CloseSprint();
			Assert.IsType<ClosedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}

		//Test the released to closed
		[Fact]
		public void TestReleasedToClosed()
		{
			Assert.IsType<CreatedState>(prj.ProductBacklog.Sprints[0].SprintState);
			// Start Sprints
			prj.ProductBacklog.Sprints[0].StartSprint();
			prj.ProductBacklog.Sprints[0].EndDate = DateTime.Now;
			prj.ProductBacklog.Sprints[0].EndSprint();
			prj.ProductBacklog.Sprints[0].SprintReview();
			prj.ProductBacklog.Sprints[0].UploadSummary(true);
			prj.ProductBacklog.Sprints[0].DeploymentRelease();
			prj.ProductBacklog.Sprints[0].StartDevelopmentPipeline();
			prj.ProductBacklog.Sprints[0].CloseSprint();
			Assert.IsType<ClosedState>(prj.ProductBacklog.Sprints[0].SprintState);
		}
	}
}
