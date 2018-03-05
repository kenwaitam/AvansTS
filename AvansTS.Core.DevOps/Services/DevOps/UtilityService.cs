using AvansTS.Core.DevOps.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Services
{
    public class UtilityService : IDevOpsService
    {
        public Boolean Run()
        {
            Debug.WriteLine("Start Utilities...");
            Debug.WriteLine("Utility Successful");

            return true;
        }
    }
}
