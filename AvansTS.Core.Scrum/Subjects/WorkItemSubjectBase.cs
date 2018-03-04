using AvansTS.Core.Models;
using AvansTS.Core.Observers;
using System.Collections.Generic;

namespace AvansTS.Core.Subjects
{
    public abstract class WorkItemSubjectBase : BacklogSubjectBase
    {
        public IBacklogItemObserver BacklogItem { get; set; }
        public List<User> Users { get; set; }

        public WorkItemSubjectBase()
        {
            Users = new List<User>();
        }

        public void AttachToBacklogItem(IBacklogItemObserver observer)
        {
            BacklogItem = observer;
        }

        public void Subscribe(User observer)
        {
            Users.Add(observer);
        }

        public void Unsubscribe(User observer)
        {
            Users.Remove(observer);
        }

        public void NotifyBacklogItem()
        {
            BacklogItem.Update();
        }

        public void NotifyUsers()
        {
            if (Users != null)
            {
                foreach (var user in Users)
                {
                    NotificationService.Send(user);
                }
            }
        }
    }
}
