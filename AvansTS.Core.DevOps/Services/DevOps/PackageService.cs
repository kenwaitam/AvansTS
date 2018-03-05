using AvansTS.Core.DevOps.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Services
{
    public class PackageService : IDevOpsService
    {
        public Boolean Run()
        {
            Debug.WriteLine("Start Packaging...");
            Debug.WriteLine("Package Successful");

            return true;
        }
    }
}
