using AvansTS.Core.DevOps.Command;
using Moq;
using Xunit;

namespace AvansTS.Core.DevOps.Tests
{
	public class TestCommand
	{

		[Fact]
		public void TestCommandExcecute()
		{
			var mock = new Mock<ICommand>();
			mock.Setup(d => d.Execute());

			var fake = new FakeService();

			fake.SetCommand(mock.Object);
			fake.ExecuteCommand();

			mock.Verify(d => d.Execute());
		}


		public sealed class FakeService
		{
			ICommand command;
			public void SetCommand(ICommand command)
			{
				this.command = command;
			}

			public void ExecuteCommand()
			{
				command.Execute();
			}
		}

	}
}
