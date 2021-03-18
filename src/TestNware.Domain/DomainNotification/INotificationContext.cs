using System.Collections.Generic;

namespace TestNware.Domain.DomainNotification
{
    public interface INotificationContext
    {
        IReadOnlyList<Notification> Notifications();
        bool HasNotifications();
        void AddNotification(string key, string message);
    }
}
