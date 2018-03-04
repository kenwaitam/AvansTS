using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Factories.DevOps;
using System.Collections.Generic;

namespace AvansTS.Core.DevOps.Factories
{
	public class DevOpsFactory
    {
		public static DevOpsFactory Instance { get; set; }
		public static Dictionary<int, ICommand> Factories { get; set; }

		protected DevOpsFactory() { }

		static DevOpsFactory()
		{
			Instance = new DevOpsFactory();

			Factories = new Dictionary<int, ICommand>
			{
				{ 1, new SourceCommand() },
				{ 2, new PackageCommand() },
				{ 3, new BuildCommand() },
				{ 4, new TestCommand() },
				{ 5, new DeployCommand() },
				{ 6, new UtilityCommand() }
			};
		}

		public static ICommand CreateDevopsFactory(int option)
		{
			return Factories[option];
		}
	}
}
