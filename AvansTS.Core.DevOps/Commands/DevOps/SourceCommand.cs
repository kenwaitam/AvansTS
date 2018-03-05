using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Factories;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Command
{
    public class SourceCommand : IDevOpsCommand
    {
        public Boolean Execute()
        {
            return DevOpsServiceFactory.CreateDevOpsServiceFactory(1).CreateDevOpsService().Run();
        }
    }
}
