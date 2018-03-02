using AvansTS.Core.Models;
using AvansTS.Core.Observers;
using AvansTS.Core.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AvansTS.Core.Services
{
    public class NotificationService : INotificationObserver
    {
        public void Send(User user)
        {
            foreach (var option in user.NotificationOptions)
            {
                NotificationFactory.CreateNotificationFactory(option).CreateNotificationService().Send(user);
            }
        }
    }
}
