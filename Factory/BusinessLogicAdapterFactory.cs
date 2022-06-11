using BusinessLogicAdapter;
using BusinessLogicAdapter.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Factory;
internal static class BusinessLogicAdapterFactory
{
    public static void InjectBusinessLogicsAdapter(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(CoinAccountProfile));
        services.AddTransient<UserLogicAdapter>();
        services.AddTransient<SessionLogicAdapter>();
        services.AddTransient<TransactionLogicAdapter>();
    }
}
