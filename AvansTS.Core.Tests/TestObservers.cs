using System.IO;
using System.Linq;
using Xunit;
using Moq;
using AvansTS.Core.Observers;

namespace AvansTS.Core.Tests
{
	public class TestObservers : TestDataFixture
    {
		public TestObservers()
		{
			// Add Tasks to ToDo, Doing, Done
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].IsDone();
		}

		//Test backlog item observer
		[Fact]
		public void TestObserver()
		{
			var mock = new Mock<IBacklogItemObserver>();
			mock.Setup(o => o.Update());
			//prj.ProductBacklog.Sprints[0].Items[0].AttachToBacklogItem(prj.ProductBacklog.Sprints[0].Items[0]);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			mock.Verify(o => o.Update());
		}

		//Test backlog item is done
		[Fact]
		public void TestBacklogItemDone()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			Assert.True(prj.ProductBacklog.Sprints[0].Items[0].Done);
		}

		//Test scrummaster slack notification
		[Fact]
		public void TestBacklogItemTaskBackToToDoSlackNotification()
		{
			prj.ProductBacklog.Sprints[0].AssignScrummaster(dev2);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var slack = File.ReadLines("./Logs/SlackLog.txt").Last();

			Assert.Equal("Slack notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Name, slack);
			Assert.False(prj.ProductBacklog.Sprints[0].Items[0].Done);
		}

		//Test scrummaster email notification
		[Fact]
		public void TestBacklogItemTaskBackToToDoEmailNotification()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();
			
			var email = File.ReadLines("./Logs/EmailLog.txt").Last();
			
			Assert.Equal("Email notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Email, email);
			Assert.False(prj.ProductBacklog.Sprints[0].Items[0].Done);
		}

		//Test backlog item task is put back to todo from done
		[Fact]
		public void TestBacklogItemTaskBackToToDoNotification()
		{
			dev1.AddOption(2);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var slack = File.ReadLines("./Logs/SlackLog.txt").Last();
			var email = File.ReadLines("./Logs/EmailLog.txt").Last();

			Assert.Equal("Slack notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Name, slack);
			Assert.Equal("Email notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Email, email);
			Assert.False(prj.ProductBacklog.Sprints[0].Items[0].Done);
		}
	}
}
