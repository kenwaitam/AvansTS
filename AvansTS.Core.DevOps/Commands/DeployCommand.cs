using AvansTS.Core.DevOps.Services;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
	public class DeployCommand : ICommand
	{
		public void Execute()
		{
			ICommand build = new DeployCommand();
			build.Execute();
		}
	}
}
