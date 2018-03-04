using AvansTS.Core.DevOps.Factories;
using System.Diagnostics;

namespace AvansTS.Core.DevOps.Command
{
	public class TestCommand : IDevOpsCommand
	{
		public void Execute()
		{
			DevOpsFactory.CreateDevOpsFactory(4).CreateDevOpsService().Run();
		}
	}
}
