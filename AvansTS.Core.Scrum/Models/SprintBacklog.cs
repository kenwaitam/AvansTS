﻿using AvansTS.Core.Factories;
using AvansTS.Core.Models.Base;
using AvansTS.Core.Scrum.Models;
using AvansTS.Core.Services;
using AvansTS.Core.States;
using AvansTS.Core.States.Sprint;
using AvansTS.Core.States.Sprint.Implementations;
using System;
using System.Collections.Generic;

namespace AvansTS.Core.Models
{
    public class SprintBacklog : BacklogBase, ISprintState
    {
        public Project Project { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsCurrent { get; set; }
        public Boolean IsSubmitted { get; set; }
        public Report Report { get; set; }
        public User Scrummaster { get; set; }
        public List<User> Developers { get; set; }

        public SprintStateBase SprintState { get; set; }
        public SprintStateBase CreatedState { get; set; }
        public SprintStateBase StartedState { get; set; }
        public SprintStateBase FinishedState { get; set; }
        public SprintStateBase ReviewState { get; set; }
        public SprintStateBase ReleasingState { get; set; }
        public SprintStateBase CanceledState { get; set; }
        public SprintStateBase ReleasedState { get; set; }
        public SprintStateBase ClosedState { get; set; }

        public SprintBacklog(Project project)
        {
            CreatedState = new CreatedState(this);
            StartedState = new StartedState(this);
            FinishedState = new FinishedState(this);
            ReviewState = new ReviewState(this);
            ReleasingState = new ReleasingState(this);
            CanceledState = new CanceledState(this);
            ReleasedState = new ReleasedState(this);
            ClosedState = new ClosedState(this);

            Project = project;

            SprintState = CreatedState;

            AttachToNotificationService(new NotificationService());
        }

        public void CreateReport(Report report)
        {
            Report = report;
        }

        public void SaveReport(int option = 1)
        {
            if (Report != null)
            {
                FormatFactory.CreateFormatFactory(option).CreateFormatService().Convert(Report);
            }
        }

        public void AssignScrummaster(User user)
        {
            Scrummaster = user;
        }

        public void AddDeveloper(User user)
        {
            Developers.Add(user);
        }

        public virtual void UpdateName(String name)
        {
            SprintState.UpdateName(name);
        }

        public virtual void UpdateDate(DateTime startDate, DateTime endDate)
        {
            SprintState.UpdateDate(startDate, endDate);
        }

        public override void AddItem(ProductBacklogItem item)
        {
            SprintState.AddItem(item);
        }

        public virtual void StartSprint()
        {
            SprintState.StartSprint();
        }

        public virtual void EndSprint()
        {
            SprintState.EndSprint();
        }

        public virtual void SprintReview()
        {
            SprintState.SprintReview();
        }

        public virtual void UploadSummary(Boolean summary)
        {
            SprintState.UploadSummary(summary);
        }

        public virtual void DeploymentRelease()
        {
            SprintState.DeploymentRelease();
        }

        public virtual void DeploymentCanceled()
        {
            SprintState.DeploymentCanceled();
        }

        public virtual void StartDevelopmentPipeline(int x)
        {
            SprintState.StartDevelopmentPipeline(x);
        }

        public virtual void CloseSprint()
        {
            SprintState.CloseSprint();
        }
    }
}
