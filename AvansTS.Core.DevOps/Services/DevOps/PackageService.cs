using AvansTS.Core.DevOps.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Services
{
    class PackageService : IDevOpsService
    {
		public void Run()
		{
			Debug.WriteLine("Packaged");
		}
	}
}
