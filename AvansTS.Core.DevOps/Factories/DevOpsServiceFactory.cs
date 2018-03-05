using AvansTS.Core.DevOps.Command;
using AvansTS.Core.DevOps.Factories.DevOps;
using System.Collections.Generic;

namespace AvansTS.Core.DevOps.Factories
{
    public class DevOpsServiceFactory
    {
        public static DevOpsServiceFactory Instance { get; set; }
        public static Dictionary<int, IDevOpsServiceFactory> Factories { get; set; }

        protected DevOpsServiceFactory() { }

        static DevOpsServiceFactory()
        {
            Instance = new DevOpsServiceFactory();

            Factories = new Dictionary<int, IDevOpsServiceFactory>
            {
                { 1, new SourceServiceFactory() },
                { 2, new PackageServiceFactory() },
                { 3, new BuildServiceFactory() },
                { 4, new TestServiceFactory() },
                { 5, new DeployServiceFactory() },
                { 6, new UtilityServiceFactory() }
            };
        }

        public static IDevOpsServiceFactory CreateDevOpsServiceFactory(int option)
        {
            return Factories[option];
        }
    }
}
