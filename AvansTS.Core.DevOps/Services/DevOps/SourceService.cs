using AvansTS.Core.DevOps.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Services
{
	public class SourceService : IDevOpsService
	{
		public void Run()
		{
			Debug.WriteLine("Source");
		}
	}
}
