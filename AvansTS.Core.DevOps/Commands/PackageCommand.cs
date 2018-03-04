using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Command
{
	public class PackageCommand : ICommand
	{
		public void Execute()
		{
			IDevOpsService package = new PackageService();
			package.Run();
		}
	}
}
