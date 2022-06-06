using System;
using System.Linq;
using Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Tests;

public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<MyContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<DbContext, MyContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryEmployeeTest");
            });

            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<MyContext>();
            try
            {
                appContext.Database.EnsureCreated();
            }
            catch (Exception)
            {
                Console.WriteLine("In memory database start error.");
                throw;
            }
        });
    }
}