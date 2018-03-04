using AvansTS.Core.DevOps.Command;
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
			ICommand build = new BuildCommand();
			build.Execute();
		}
    }
}
