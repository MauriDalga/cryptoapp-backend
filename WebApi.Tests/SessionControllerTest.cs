using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain;
using Model.Read;
using Model.Write;
using WebApi.Tests.Helpers;
using Xunit;

namespace WebApi.Tests;

public class SessionControllerTest : BaseIntegrationTest
{
    private readonly User _testUserEntity = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com",
        Password = "test_password",
        Token = "1234-5678-90"
    };

    private readonly UserDetailInfoModel _testUserModel = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com",
        Token = "1234-5678-90"
    };

    public SessionControllerTest(TestingWebAppFactory<Program> factory) : base(factory)
    {
        Context.Users.RemoveRange(Context.Users);
        Context.CoinAccounts.RemoveRange(Context.CoinAccounts);
        Context.SaveChanges();
    }

    [Fact]
    public async Task TestLoginOk()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();

        SessionModel sessionModel = new()
        {
            Email = "john.doe@test.com",
            Password = "test_password"
        };

        var response = await HttpClient.PostAsync("api/login", TestUtils.GetJsonHttpContentFrom(sessionModel));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseUser = await response.Content.ReadFromJsonAsync<UserDetailInfoModel>();
        Assert.NotNull(responseUser);
        Assert.Equal(_testUserModel, responseUser);
        Assert.Equal(1, Context.Users.Count());
    }

    [Fact]
    public async Task TestLoginInvalid()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();

        SessionModel sessionModel = new()
        {
            Email = "john.doe@test.com",
            Password = "test_wrong_password"
        };
        const string expectedErrorMsg = "Invalid credentials.";

        var response = await HttpClient.PostAsync("api/login", TestUtils.GetJsonHttpContentFrom(sessionModel));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
    }
}