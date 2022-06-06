using System;
using System.Linq;
using System.Net.Http;
using Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WebApi.Tests;

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