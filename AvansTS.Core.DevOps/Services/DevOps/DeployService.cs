using AvansTS.Core.DevOps.Factories;
using System;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Services
{
    public class DeployService : IDevOpsService
    {
        public Boolean Run()
        {
            Debug.WriteLine("Start Deploying...");
            Debug.WriteLine("Deploy Successful");

            return true;
        }
    }
}
