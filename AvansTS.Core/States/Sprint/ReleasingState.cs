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
			Sprint.SprintState = Sprint.ReleasedState;
		}
	}
}
