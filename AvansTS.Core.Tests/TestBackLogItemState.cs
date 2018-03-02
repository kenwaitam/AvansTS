using AvansTS.Core.States.BacklogItem;
using Xunit;

namespace AvansTS.Core.Tests
{
	public class TestBackLogItemState : TestDataFixture
    {
		//Test the first state
		[Fact]
		public void FirstState()
		{
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}

		//Test Todo to Doing state
		[Fact]
		public void ToDo_To_Doing()
		{
			prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.InProgress();
			Assert.IsType<DoingState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}

		//Test Doing to Done state
		[Fact]
		public void Doing_To_Done()
		{
			prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
		}

		//Test Done to ToDo state
		[Fact]
		public void Done_To_ToDo()
		{
			prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.InProgress();
			prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.IsDone();
			Assert.IsType<DoneState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);
			prj.ProductBacklog.Sprints[0].Items[0].WorkItemState.InToDo();
			Assert.IsType<ToDoState>(prj.ProductBacklog.Sprints[0].Items[0].WorkItemState);

		}
	}
}
