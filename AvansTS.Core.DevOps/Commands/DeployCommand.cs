using AvansTS.Core.DevOps.Services;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
	public class DeployCommand : ICommand
	{
		public void Execute()
		{
			IDevOpsService deploy = new DeployService();
			deploy.Run();
		}
	}
}
