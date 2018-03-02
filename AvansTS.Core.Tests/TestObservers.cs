using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

		//Test backlog item is done
		[Fact]
		public void TestBacklogItemDone()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			Assert.True(prj.ProductBacklog.Sprints[0].Items[0].IsDone);
		}

		//Test scrummaster slack notification
		[Fact]
		public void TestBacklogItemTaskBackToToDoSlackNotification()
		{
			prj.ProductBacklog.Sprints[0].Items[0].AssignDeveloper(dev2);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var slack = File.ReadLines("./SlackLog.txt").Last();

			Assert.Equal("Slack notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Name, slack);
			Assert.False(prj.ProductBacklog.Sprints[0].Items[0].IsDone);
		}

		//Test scrummaster email notification
		[Fact]
		public void TestBacklogItemTaskBackToToDoEmailNotification()
		{
			dev1.AddOption(1);
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();
			
			var email = File.ReadLines("./EmailLog.txt").Last();
			
			Assert.Equal("Email notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Email, email);
			Assert.False(prj.ProductBacklog.Sprints[0].Items[0].IsDone);
		}

		//Test backlog item task is put back to todo from done
		[Fact]
		public void TestBacklogItemTaskBackToToDoNotification()
		{
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[1].IsDone();
			prj.ProductBacklog.Sprints[0].Items[0].Tasks[0].InToDo();

			var slack = File.ReadLines("./SlackLog.txt").Last();
			var email = File.ReadLines("./EmailLog.txt").Last();

			Assert.Equal("Slack notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Name, slack);
			Assert.Equal("Email notification sended to " + prj.ProductBacklog.Sprints[0].Scrummaster.Email, email);
			Assert.False(prj.ProductBacklog.Sprints[0].Items[0].IsDone);
		}
	}
}
