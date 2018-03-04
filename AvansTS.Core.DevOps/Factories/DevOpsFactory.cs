using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Factories.DevOps;
using System.Collections.Generic;

namespace AvansTS.Core.DevOps.Factories
{
	public class DevOpsFactory
    {
		public static DevOpsFactory Instance { get; set; }
		public static Dictionary<int, IDevOpsFactory> Factories { get; set; }

		protected DevOpsFactory() { }

		static DevOpsFactory()
		{
			Instance = new DevOpsFactory();

			Factories = new Dictionary<int, IDevOpsFactory>
			{
				{ 1, new SourcesFactory() },
				{ 2, new PackageFactory() },
				{ 3, new BuildFactory() },
				{ 4, new TestFactory() },
				{ 5, new DeployFactory() },
				{ 6, new UtilityFactory() }
			};
		}

		public static IDevOpsFactory CreateDevOpsFactory(int option)
		{
			return Factories[option];
		}
	}
}
