using AvansTS.Core.Services;
using AvansTS.Core.Services.Notification;

namespace AvansTS.Core.Factories.Notification
{
    public class SlackFactory : INotificationFactory
    {
        INotificationService INotificationFactory.CreateNotificationService()
        {
            return new SlackService();
        }
    }
}
