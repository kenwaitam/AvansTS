using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Services
{
    public class BuildService : IDevOpsService
	{
		public void Run()
		{
			Debug.WriteLine("Build");
		}
    }
}
