using AvansTS.Core.DevOps.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Services
{
    public class BuildService : IDevOpsService
    {
        public Boolean Run()
        {
            Debug.WriteLine("Start Building...");
            Debug.WriteLine("Build Successful");

            return true;
        }
    }
}
