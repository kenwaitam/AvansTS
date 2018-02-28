using AvansTS.Core.Factories;
using AvansTS.Core.Factories.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvansTS.Core.Singletons
{
    public class NotificationFactory
    {
        public static NotificationFactory Instance { get; set; }
        public static Dictionary<int, INotificationFactory> Factories { get; set; }

        protected NotificationFactory() { }

        static NotificationFactory()
        {
            Instance = new NotificationFactory();

            Factories = new Dictionary<int, INotificationFactory>
            {
                { 1, new EmailFactory() },
                { 2, new SlackFactory() }
            };
        }

        public static INotificationFactory CreateNotificationFactory(int option)
        {
            return Factories[option];
        }
    }
}
