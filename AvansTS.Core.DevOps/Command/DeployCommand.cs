using AvansTS.Core.DevOps.Services;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
	public class DeployCommand : CommandBase
	{
		public override void Execute()
		{
			IDevOpsService deploy = new DeployService();
			deploy.Run();
		}
	}
}
