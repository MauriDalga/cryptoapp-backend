namespace ServicesInterface
{
    public interface INotificationService
    {
        Task SendNotification(string deviceToken, string body);
    }
}