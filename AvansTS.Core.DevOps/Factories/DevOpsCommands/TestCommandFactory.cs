using System;
using System.Collections.Generic;
using System.Text;
using AvansTS.Core.DevOps.Command;

namespace AvansTS.Core.DevOps.Factories.DevOpsCommands
{
    public class TestCommandFactory : IDevOpsCommandFactory
    {
        public IDevOpsCommand CreateDevOpsCommand()
        {
            return new TestCommand();
        }
    }
}
