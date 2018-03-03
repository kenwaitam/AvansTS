using AvansTS.Core.Models;
using System;

namespace AvansTS.Core.States
{
	public interface ISprintState
	{
		void UpdateName(String name);
		void UpdateDate(DateTime startDate, DateTime endDate);
		void AddItem(ProductBacklogItem item);
		void StartSprint();
		void EndSprint();
		void SprintReview();
		void UploadSummary(Boolean summary);
		void DeploymentRelease();
		void DeploymentCanceled();
		void StartDevelopmentPipeline();
		void CloseSprint();
	}
}
