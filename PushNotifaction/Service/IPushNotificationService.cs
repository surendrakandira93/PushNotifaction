using PushNotifaction.Models;

namespace PushNotifaction.Service
{
    public interface IPushNotificationService
    {
        Task<bool> PushNotifications(PushNotificationItemDto item);
    }
}
