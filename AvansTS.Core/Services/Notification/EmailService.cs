using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AvansTS.Core.Models;

namespace AvansTS.Core.Services.Notification
{
    public class EmailService : INotificationService
    {
        public void Send(User user)
        {
            Debug.WriteLine("Email notification sended to " + user.Email);
        }
    }
}
