using AvansTS.Core.Factories;
using AvansTS.Core.Factories.Notification;
using AvansTS.Core.Models;
using AvansTS.Core.Models.Base;
using AvansTS.Core.Observers;
using AvansTS.Core.Singletons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.Subjects
{
    public abstract class TaskSubjectBase : WorkItemBase
    {
        public IBacklogItemObserver BacklogItem { get; set; }

        public void AttachToBacklogItem(IBacklogItemObserver observer)
        {
            BacklogItem = observer;
        }

        public void NotifyBacklogItem()
        {
            BacklogItem.Update();
        }

        public void NotifyScrummaster(Developer user)
        {
            foreach (var option in user.NotificationOptions)
            {
                NotificationFactory.CreateNotificationFactory(option).CreateNotificationService().Send(user);
            }
        }
    }
}
