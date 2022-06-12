using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain;
using Model.Read;
using Model.Write;
using WebApi.Tests.Helpers;
using Xunit;

namespace WebApi.Tests;

public class UserControllerTest : BaseIntegrationTest
{
    private readonly User _testUserEntity = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com",
        Password = "test_password1",
        Token = "1234-5678-90",
        Image = "some-image-base64"
    };

    private readonly UserDetailInfoModel _testUserModel = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com",
        Token = "1234-5678-90",
        Image = "some-image-base64"
    };

    public UserControllerTest(TestingWebAppFactory<Program> factory) : base(factory)
    {
        Context.Users.RemoveRange(Context.Users);
        Context.CoinAccounts.RemoveRange(Context.CoinAccounts);
        Context.SaveChanges();
    }

    [Fact]
    public async Task TestGetByIdUserOk()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.GetAsync($"api/users/{_testUserEntity.Id}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseUser = await response.Content.ReadFromJsonAsync<UserDetailInfoModel>();
        Assert.NotNull(responseUser);
        Assert.Equal(_testUserModel, responseUser);
    }

    [Fact]
    public async Task TestGetByIdUserNotFound()
    {
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.GetAsync($"api/users/{1}");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Equal("{\"message\":\"Header 'Authorization' expired or invalid.\"}", (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestPostUserOk()
    {
        UserModel userModel = new()
        {
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "test_password"
        };

        var response = await HttpClient.PostAsync("api/users", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var responseUser = response.Content.ToString();
        Assert.NotNull(responseUser);
        Assert.Equal(1, Context.Users.Count());
    }

    [Fact]
    public async Task TestPostInvalidUser()
    {
        UserModel userModel = new()
        {
            Name = "",
            Email = "user_1@gmail.com",
            Password = "Password_1",
        };

        const string expectedErrorMsg = "Property 'name' can't be empty. \n Property 'lastname' can't be empty.";

        var response = await HttpClient.PostAsync("api/users", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestPutUserOk()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();

        UserModel userModel = new()
        {
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "test_password",
            Image = "some-other-image-base64"
        };

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.PutAsync($"api/users/{1}", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task TestPutInvalidUser()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();
        UserModel userModel = new()
        {
            Name = "",
            Email = "user_1@gmail.com",
            Password = "Password_1",
        };
        const string expectedErrorMsg = "Property 'name' can't be empty. \n Property 'lastname' can't be empty.";

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.PutAsync($"api/users/{1}", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestPutUserNotFound()
    {
        UserModel userModel = new()
        {
            Name = "John",
            Lastname = "Doe",
            Email = "john.doe@test.com",
            Password = "Password_1",
        };

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.PutAsync($"api/users/{1}", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Equal("{\"message\":\"Header 'Authorization' expired or invalid.\"}", (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestDeleteUserOk()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.DeleteAsync($"api/users/{1}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.False(Context.Users.AsEnumerable().Any());
    }

    [Fact]
    public async Task TestDeleteUserNotFound()
    {
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.DeleteAsync($"api/users/{5}");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Equal("{\"message\":\"Header 'Authorization' expired or invalid.\"}", (await response.Content.ReadAsStringAsync()));
    }
}