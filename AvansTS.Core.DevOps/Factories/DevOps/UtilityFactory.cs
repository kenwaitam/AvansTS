using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.DevOps.Factories.DevOps
{
    public class UtilityFactory : IDevOpsFactory
    {
		public CommandBase CreateDevOpsCommand()
		{
			return new UtilityCommand();
		}
	}
}
