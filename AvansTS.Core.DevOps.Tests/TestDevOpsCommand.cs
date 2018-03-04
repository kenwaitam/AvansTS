using System;
using Xunit;
using Moq;
using AvansTS.Core.DevOps.Command;

namespace AvansTS.Core.DevOps.Tests
{
    public class TestCommand
    {
        [Fact]
        public void TestCommandExcecute()
        {
			var mock = new Mock<CommandBase>();
			mock.Setup(d => d.Execute());

		}
    }
}
