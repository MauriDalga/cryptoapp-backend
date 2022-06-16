using Microsoft.Extensions.DependencyInjection;
using Services;
using ServicesInterface;

namespace Factory;
internal static class NotificationsFactory
{
    public static void InjectNotifications(this IServiceCollection services)
    {
        services.AddTransient<INotificationService, NotificationService>();
    }
}