using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Factories;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Command
{
	public class UtilityCommand : IDevOpsCommand
	{
		public void Execute()
		{
			DevOpsFactory.CreateDevOpsFactory(6).CreateDevOpsService().Run();
		}
	}
}
