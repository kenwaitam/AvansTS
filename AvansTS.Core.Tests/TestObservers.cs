using AvansTS.Core.Observers;
using AvansTS.Core.States.WorkItem;
using Moq;
using System.IO;
using System.Linq;
using Xunit;

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
		public void TestBackLogItemObserver()
		{
			var mock = new Mock<IBacklogItemObserver>();
			mock.Setup(o => o.Update());
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].AttachToBacklogItem(mock.Object);

			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();

			mock.Verify(o => o.Update());
		}

		//Test notification observer
		[Fact]
		public void TestNotificationObserver()
		{
			var mock = new Mock<INotificationObserver>();
			mock.Setup(o => o.Send(dev1));
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].AttachToNotificationService(mock.Object);

			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].InToDo();

			mock.Verify(o => o.Send(dev1));
		}

		//Test backlog item is done
		[Fact]
		public void TestBacklogItemDone()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}

		//Test scrummaster slack notification
		[Fact]
		public void TestBacklogItemTaskBackToToDoSlackNotification()
		{
			dev2.AddOption(2);
			prj.ProductBacklog.Sprints[0].AssignScrummaster(dev2);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var slack = File.ReadAllLines("./Logs/SlackLog.txt").Last();

			Assert.Equal("Slack notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Name, slack);
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}

		//Test scrummaster email notification
		[Fact]
		public void TestBacklogItemTaskBackToToDoEmailNotification()
		{
			dev1.AddOption(1);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var email = File.ReadAllLines("./Logs/EmailLog.txt").Last();

			Assert.Equal("Email notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Email, email);
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}

		//Test backlog item task is put back to todo from done
		[Fact]
		public void TestBacklogItemTaskBackToToDoNotification()
		{
			dev1.AddOption(1);
			dev1.AddOption(2);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var slack = File.ReadAllLines("./Logs/SlackLog.txt").Last();
			var email = File.ReadAllLines("./Logs/EmailLog.txt").Last();

			Assert.Equal("Slack notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Name, slack);
			Assert.Equal("Email notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Email, email);
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}
	}
}
