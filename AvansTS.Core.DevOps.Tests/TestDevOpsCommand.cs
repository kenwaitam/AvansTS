using System;
using Xunit;
using Moq;
using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Factories;
using System.Collections.Generic;

namespace AvansTS.Core.DevOps.Tests
{
    public class TestCommand
    {

		[Fact]
        public void TestCommandExcecute()
        {
			var mock = new Mock<CommandBase>();
			mock.Setup(d => d.Execute());
			DevOpsFactory.Factories.Add(7, mock.Object);

			var dev = DevOpsFactory.CreateDevopsFactory(7);
			dev.Execute();

			mock.Verify(d => d.Execute());
		}
    }
}
