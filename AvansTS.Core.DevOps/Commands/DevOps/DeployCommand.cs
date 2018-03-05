using AvansTS.Core.DevOps.Factories;
using System;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
    public class DeployCommand : IDevOpsCommand
    {
        public Boolean Execute()
        {
            return DevOpsServiceFactory.CreateDevOpsServiceFactory(5).CreateDevOpsService().Run();
        }
    }
}
