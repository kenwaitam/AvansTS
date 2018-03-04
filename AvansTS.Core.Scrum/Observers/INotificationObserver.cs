using AvansTS.Core.Models;

namespace AvansTS.Core.Observers
{
    public interface INotificationObserver
    {
        void Send(User user);
    }
}
