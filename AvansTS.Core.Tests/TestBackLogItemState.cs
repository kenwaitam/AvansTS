using AvansTS.Core.States.BacklogItem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AvansTS.Core.Tests
{
	public class TestBackLogItemState : TestDataFixture
    {
		//Test the first state
		[Fact]
		public void FirstState()
		{
			var state = prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.State;
			Assert.Equal("ToDo", state);
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}
	}
}
