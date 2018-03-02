using AvansTS.Core.Models;

namespace AvansTS.Core.States.Sprint
{
	public class ClosedState : SprintStateBase
	{
		public SprintBacklog Sprint { get; set; }

		public override string State { get { return "Closed"; } }

		public ClosedState(SprintBacklog sprint)
		{
			Sprint = sprint;
		}
	}
}
