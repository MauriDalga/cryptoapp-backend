using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Write;

namespace Factory;
public class BaseFactory
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;

    public BaseFactory(IServiceCollection services, IConfiguration configuration)
    {
        _services = services;
        _configuration = configuration;
    }

    public void InjectDependencies()
    {
        _services.InjectBusinessLogicsAdapter();
        _services.InjectBusinessLogics();
        _services.InjectDataAccess(_configuration.GetConnectionString("MyDataBaseConnectionString"));
        _services.InjectSession();
        _services.InjectValidators();
        _services.InjectNotifications();

        _services.Configure<FcmNotificationSetting>(_configuration.GetSection("FcmNotification"));
    }
}