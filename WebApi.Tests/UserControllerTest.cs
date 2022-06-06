using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain;
using Model.Read;
using Model.Write;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebApi.Tests;

public class UserControllerTest : BaseIntegrationTest
{
    private readonly User _testUserEntity = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com",
        Password = "test_password1"
    };

    private readonly UserDetailInfoModel _testUserModel = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com"
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

        var response = await HttpClient.GetAsync($"users/{_testUserEntity.Id}");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var responseUser = await response.Content.ReadFromJsonAsync<UserDetailInfoModel>();
        Assert.IsNotNull(responseUser);
        Assert.AreEqual(_testUserModel, responseUser);
    }

    [Fact]
    public async Task TestGetByIdUserNotFound()
    {
        var response = await HttpClient.GetAsync($"users/{1}");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        Assert.AreEqual("ID: 1 not found.", (await response.Content.ReadAsStringAsync()));
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

        var response = await HttpClient.PostAsync("users", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        var responseUser = await response.Content.ReadFromJsonAsync<UserDetailInfoModel>();
        Assert.IsNotNull(responseUser);
        Assert.AreEqual(_testUserModel, responseUser);
        Assert.AreEqual(1, Context.Users.Count());
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

        var response = await HttpClient.PostAsync("users", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.AreEqual(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
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

        var response = await HttpClient.PutAsync($"users/{1}", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.AreEqual(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
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

        var response = await HttpClient.PutAsync($"users/{1}", TestUtils.GetJsonHttpContentFrom(userModel));

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        Assert.AreEqual("ID: 1 not found.", (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestDeleteUserOk()
    {
        Context.Users.Add(_testUserEntity);
        await Context.SaveChangesAsync();
        var response = await HttpClient.DeleteAsync($"users/{1}");

        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        Assert.IsFalse(Context.Users.AsEnumerable().Any());
    }

    [Fact]
    public async Task TestDeleteUserNotFound()
    {
        var response = await HttpClient.DeleteAsync($"users/{5}");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        Assert.AreEqual("ID: 5 not found.", (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestGetAccountsFromUserOk()
    {
        await Context.Users.AddAsync(_testUserEntity);
        await Context.CoinAccounts.AddRangeAsync(new CoinAccount
            {
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                CoinId = 2,
                Balance = 10,
                UserId = 1
            });
        await Context.SaveChangesAsync();

        var response = await HttpClient.GetAsync($"users/{1}/coin-accounts");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var responseCoinAccounts = await response.Content.ReadFromJsonAsync<IEnumerable<CoinAccountModel>>();
        Assert.IsNotNull(responseCoinAccounts);
        Assert.AreEqual(2, responseCoinAccounts.Count());
    }

    [Fact]
    public async Task TestGetAccountsFromUserNotFound()
    {
        var response = await HttpClient.GetAsync($"users/{1}/coin-accounts");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        Assert.IsTrue((await response.Content.ReadAsStringAsync()).Contains("ID: 1 not found"));
    }
}