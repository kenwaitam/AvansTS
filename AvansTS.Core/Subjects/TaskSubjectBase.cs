using AvansTS.Core.Models;
using AvansTS.Core.Models.Base;
using AvansTS.Core.Observers;

namespace AvansTS.Core.Subjects
{
    public abstract class TaskSubjectBase : WorkItemBase
    {
        public IBacklogItemObserver BacklogItem { get; set; }
        public INotificationObserver NotificationService { get; set; }

        public void AttachToBacklogItem(IBacklogItemObserver observer)
        {
            BacklogItem = observer;
        }

        public void AttachToNotificationService(INotificationObserver observer)
        {
            NotificationService = observer;
        }

        public void NotifyBacklogItem()
        {
            BacklogItem.Update();
        }

        public void NotifyScrummaster(User user)
        {
            NotificationService.Send(user);
        }
    }
}
