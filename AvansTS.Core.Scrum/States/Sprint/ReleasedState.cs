using AvansTS.Core.Models;

namespace AvansTS.Core.States.Sprint
{
    public class ReleasedState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public override string State { get { return "Released"; } }

        public ReleasedState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void CloseSprint()
        {
            Sprint.SprintState = Sprint.ClosedState;
            Sprint.IsCurrent = false;
        }
    }
}
