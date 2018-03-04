using AvansTS.Core.DevOps.Factories;
using AvansTS.Core.Models;

namespace AvansTS.Core.States.Sprint
{
    public class ReleasingState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public override string State { get { return "Releasing"; } }

        public ReleasingState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void StartDevelopmentPipeline()
        {
			// DevOps: Start Source
			DevOpsFactory.CreateDevOpsFactory(1).CreateDevOpsService().Run();
			// DevOps: Start Packaging
			DevOpsFactory.CreateDevOpsFactory(2).CreateDevOpsService().Run();
			// DevOps: Start Building
			DevOpsFactory.CreateDevOpsFactory(3).CreateDevOpsService().Run();
			// DevOps: Start Testing
			DevOpsFactory.CreateDevOpsFactory(4).CreateDevOpsService().Run();
			// DevOps: Start Deploying
			DevOpsFactory.CreateDevOpsFactory(5).CreateDevOpsService().Run();
			// DevOps: Do Utility
			DevOpsFactory.CreateDevOpsFactory(6).CreateDevOpsService().Run();

			Sprint.SprintState = Sprint.ReleasedState;
		}
    }
}
