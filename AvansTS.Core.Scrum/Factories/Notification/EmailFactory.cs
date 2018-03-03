using AvansTS.Core.Services;
using AvansTS.Core.Services.Notification;

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
