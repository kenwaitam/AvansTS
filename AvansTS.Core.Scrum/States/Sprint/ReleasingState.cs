using AvansTS.Core.DevOps.Command;
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

        public override void StartDevelopmentPipeline(int x)
        {
            var pipeline = false;

            do
            {
                // DevOps: Start Sources, Packaging, Building, Testing, Deploying, Utilities
                pipeline = DevOpsCommandFactory.CreateDevOpsCommandFactory(x).CreateDevOpsCommand().Execute();

                if (pipeline == false)
                {
                    Sprint.NotifyUser(Sprint.Scrummaster);
                    break;
                }

                x++;
            } while (x <= 6);

            if (pipeline == true)
            {
                Sprint.SprintState = Sprint.ReleasedState;
                Sprint.NotifyUser(Sprint.Scrummaster);

                foreach (var user in Sprint.Project.ProductOwners)
                {
                    Sprint.NotifyUser(user);
                }
            }
        }

        public override void DeploymentCanceled()
        {
            Sprint.SprintState = Sprint.CanceledState;
            Sprint.NotifyUser(Sprint.Scrummaster);

            foreach (var user in Sprint.Project.ProductOwners)
            {
                Sprint.NotifyUser(user);
            }
        }
    }
}
