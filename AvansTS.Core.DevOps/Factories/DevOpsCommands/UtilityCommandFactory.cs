using System;
using System.Collections.Generic;
using System.Text;
using AvansTS.Core.DevOps.Command;

namespace AvansTS.Core.DevOps.Factories.DevOpsCommands
{
    public class UtilityCommandFactory : IDevOpsCommandFactory
    {
        public IDevOpsCommand CreateDevOpsCommand()
        {
            return new UtilityCommand();
        }
    }
}
