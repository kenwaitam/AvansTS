﻿using AvansTS.Core.Services;
using AvansTS.Core.Services.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Factories.Notification
{
    public class EmailFactory : INotificationFactory
    {
        INotificationService INotificationFactory.CreateNotificationService()
        {
            return new EmailService();
        }
    }
}