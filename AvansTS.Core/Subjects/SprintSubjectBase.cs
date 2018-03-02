using AvansTS.Core.Models;
using AvansTS.Core.Models.Base;
using AvansTS.Core.Observers;
using System.Collections.Generic;

namespace AvansTS.Core.Subjects
{
	public abstract class SprintSubjectBase : BacklogBase
	{
		public INotificationObserver NotificationService { get; set; }

		public void AttachToNotificationService(INotificationObserver observer)
		{
			NotificationService = observer;
		}

		public void NotifyProductOwners(List<User> users)
		{
			foreach (var user in users)
			{
				NotificationService.Send(user);
			}
		}

		public void NotifyScrummaster(User user)
		{
			NotificationService.Send(user);
		}
	}
}
