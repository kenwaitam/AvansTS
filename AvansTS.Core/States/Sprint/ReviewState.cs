using AvansTS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.States.Sprint
{
    public class ReviewState : SprintStateBase
    {
        public SprintBacklog Sprint { get; set; }

        public ReviewState(SprintBacklog sprint)
        {
            Sprint = sprint;
        }

        public override void UploadSummary(bool summary)
        {
            Sprint.IsSubmitted = summary;
        }

        public override void DeploymentRelease()
        {
            if (Sprint.IsSubmitted == true)
            {
                Sprint.SprintState = Sprint.ReleasingState;
            }
        }

        public override void DeploymentCanceled()
        {
            if (Sprint.IsSubmitted == true)
            {
                Sprint.NotifyProductOwners(Sprint.Project.ProductOwners);
                Sprint.NotifyScrummaster(Sprint.Scrummaster);
                Sprint.SprintState = Sprint.CanceledState;
            }
        }
    }
}
