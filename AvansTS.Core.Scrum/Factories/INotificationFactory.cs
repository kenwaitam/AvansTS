using AvansTS.Core.Services;

namespace AvansTS.Core.Factories
{
    public interface INotificationFactory
    {
        INotificationService CreateNotificationService();
    }
}
