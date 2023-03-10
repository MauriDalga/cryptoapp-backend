
using System.Net.Http;
using Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace WebApi.Tests.Helpers;

public class BaseIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
{
    protected readonly HttpClient HttpClient;
    protected readonly MyContext Context;

    public BaseIntegrationTest(TestingWebAppFactory<Program> factory)
    {
        HttpClient = factory.CreateClient();
        var scopeFactory = factory.Services.GetService<IServiceScopeFactory>();
        var scope = scopeFactory!.CreateScope();
        Context = scope.ServiceProvider.GetService<MyContext>()!;
    }
}