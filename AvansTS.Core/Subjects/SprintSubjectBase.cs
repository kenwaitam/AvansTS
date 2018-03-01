using AvansTS.Core.Models;
using AvansTS.Core.Models.Base;
using AvansTS.Core.Singletons;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Subjects
{
    public abstract class SprintSubjectBase : BacklogBase
    {
        public void NotifyProductOwners(List<User> users)
        {
            foreach (var user in users)
            {
                foreach (var option in user.NotificationOptions)
                {
                    NotificationFactory.CreateNotificationFactory(option).CreateNotificationService().Send(user);
                }
            }
        }

        public void NotifyScrummaster(User user)
        {
            foreach (var option in user.NotificationOptions)
            {
                NotificationFactory.CreateNotificationFactory(option).CreateNotificationService().Send(user);
            }
        }
    }
}
