using AvansTS.Core.DevOps.Services;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
	public class DeployCommand : IDevOpsCommand
	{
		public void Execute()
		{
			IDevOpsCommand build = new DeployCommand();
			build.Execute();
		}
	}
}
