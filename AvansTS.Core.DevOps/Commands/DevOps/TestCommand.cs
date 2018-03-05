using AvansTS.Core.DevOps.Factories;
using System;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
    public class TestCommand : IDevOpsCommand
    {
        public Boolean Execute()
        {
            return DevOpsServiceFactory.CreateDevOpsServiceFactory(4).CreateDevOpsService().Run();
        }
    }
}
