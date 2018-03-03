using AvansTS.Core.Models;
using AvansTS.Core.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Subjects
{
    public abstract class BacklogSubjectBase
    {
        public INotificationObserver NotificationService { get; set; }

        public void AttachToNotificationService(INotificationObserver observer)
        {
            NotificationService = observer;
        }

        public void NotifyUser(User user)
        {
            NotificationService.Send(user);
        }
    }
}
