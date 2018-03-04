using AvansTS.Core.DevOps.Factories;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
	public class DeployCommand : IDevOpsCommand
	{
		public void Execute()
		{
			DevOpsFactory.CreateDevOpsFactory(5).CreateDevOpsService().Run();
		}
	}
}
