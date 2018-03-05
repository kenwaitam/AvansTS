using AvansTS.Core.DevOps.Factories.DevOpsCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.DevOps.Factories
{
    public class DevOpsCommandFactory
    {
        public static DevOpsCommandFactory Instance { get; set; }
        public static Dictionary<int, IDevOpsCommandFactory> Factories { get; set; }

        protected DevOpsCommandFactory() { }

        static DevOpsCommandFactory()
        {
            Instance = new DevOpsCommandFactory();

            Factories = new Dictionary<int, IDevOpsCommandFactory>
            {
                { 1, new SourceCommandFactory() },
                { 2, new PackageCommandFactory() },
                { 3, new BuildCommandFactory() },
                { 4, new TestCommandFactory() },
                { 5, new DeployCommandFactory() },
                { 6, new UtilityCommandFactory() },
            };
        }

        public static IDevOpsCommandFactory CreateDevOpsCommandFactory(int option)
        {
            return Factories[option];
        }
    }
}
