using AvansTS.Core.Models;

namespace AvansTS.Core.States.Sprint.Implementations
{
	public class FinishedState : SprintStateBase
	{
		public SprintBacklog Sprint { get; set; }

		public override string State { get { return "Finished"; } }

		public FinishedState(SprintBacklog sprint)
		{
			Sprint = sprint;
		}

		public override void SprintReview()
		{
			Sprint.SprintState = Sprint.ReviewState;
		}

		public override void DeploymentRelease()
		{
			Sprint.SprintState = Sprint.ReleasingState;
		}
	}
}
