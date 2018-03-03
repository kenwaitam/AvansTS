using AvansTS.Core.Factories;
using AvansTS.Core.Models;
using AvansTS.Core.Observers;

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
