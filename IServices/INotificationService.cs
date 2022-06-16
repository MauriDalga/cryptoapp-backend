using Model.Read;
using Model.Write;

namespace ServicesInterface
{
    public interface INotificationService
    {
        Task<NotificationResponseBasicModel> SendNotification(NotificationModel notificationModel);
    }
}