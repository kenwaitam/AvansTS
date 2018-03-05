using AvansTS.Core.DevOps.Factories;
using System;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Services
{
    public class TestService : IDevOpsService
    {
        public Boolean Run()
        {
            Debug.WriteLine("Start Testing...");
            Debug.WriteLine("Test Successful");

            return true;
        }
    }
}
