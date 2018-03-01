using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AvansTS.Core.Models;

namespace AvansTS.Core.Services.Notification
{
    public class SlackService : INotificationService
    {
        public void Send(User user)
        {
            Debug.WriteLine("Slack notification sended to " + user.Name);
        }
    }
}
