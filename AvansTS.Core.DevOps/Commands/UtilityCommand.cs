using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.DevOps.Command
{
	public class UtilityCommand : ICommand
	{
		public void Execute()
		{
			IDevOpsService utility = new UtilityService();
			utility.Run();
		}
	}
}
