﻿using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Services;

namespace AvansTS.Core.DevOps.Factories.DevOps
{
    public class BuildServiceFactory : IDevOpsServiceFactory
    {
        public IDevOpsService CreateDevOpsService()
        {
            return new BuildService();
        }
    }
}
