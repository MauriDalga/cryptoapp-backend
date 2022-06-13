using System;
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

public class TransactionControllerTest : BaseIntegrationTest
{
    private readonly Transaction _testTransactionEntity = new()
    {
        Id = 1,
        Amount = 1,
        SenderId = 1,
        ReceiverId = 2,
        Date = DateTime.Now,
        CoinId = 1
    };

    private readonly User _testSenderEntity = new()
    {
        Id = 1,
        Name = "John",
        Lastname = "Doe",
        Email = "john.doe@test.com",
        Password = "test_password",
        Token = "1234-5678-90",
        WalletAddress = "1234567890"
    };

    private readonly User _testReceiverEntity = new()
    {
        Id = 2,
        Name = "Doe",
        Lastname = "John",
        Email = "doe.john@test.com",
        Password = "test_password",
        Token = "0987-6543-21",
        WalletAddress = "0987654321"
    };

    public TransactionControllerTest(TestingWebAppFactory<Program> factory) : base(factory)
    {
        Context.Users.RemoveRange(Context.Users);
        Context.CoinAccounts.RemoveRange(Context.CoinAccounts);
        Context.Transactions.RemoveRange(Context.Transactions);
        Context.SaveChanges();
    }

    [Fact]
    public async Task TestCreateTransactionOk()
    {
        Context.Users.Add(_testSenderEntity);
        Context.Users.Add(_testReceiverEntity);
        await Context.CoinAccounts.AddRangeAsync(
            new CoinAccount
            {
                Id = 1,
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                Id = 2,
                CoinId = 1,
                Balance = 10,
                UserId = 2
            });
        await Context.SaveChangesAsync();

        TransactionModel transactionModel = new()
        {
            Amount = 0.5m,
            CoinId = 1,
            SenderId = 1,
            ReceiverWalletAddress = "0987654321"
        };

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient
            .PostAsync("api/transactions", TestUtils.GetJsonHttpContentFrom(transactionModel));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.Equal(1, Context.Transactions.Count());
    }

    [Fact]
    public async Task TestCreateTransactionWithWrongWalletAddress()
    {
        Context.Users.Add(_testSenderEntity);
        Context.Users.Add(_testReceiverEntity);
        await Context.CoinAccounts.AddRangeAsync(
            new CoinAccount
            {
                Id = 1,
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                Id = 2,
                CoinId = 1,
                Balance = 10,
                UserId = 2
            });
        await Context.SaveChangesAsync();

        TransactionModel transactionModel = new()
        {
            Amount = 0.5m,
            CoinId = 1,
            SenderId = 1,
            ReceiverWalletAddress = "09876543210"
        };

        string expectedErrorMsg = "Invalid Wallet Address.";

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient
            .PostAsync("api/transactions", TestUtils.GetJsonHttpContentFrom(transactionModel));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestCreateTransactionWithNoFunds()
    {
        Context.Users.Add(_testSenderEntity);
        Context.Users.Add(_testReceiverEntity);
        await Context.CoinAccounts.AddRangeAsync(
            new CoinAccount
            {
                Id = 1,
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                Id = 2,
                CoinId = 1,
                Balance = 10,
                UserId = 2
            });
        await Context.SaveChangesAsync();

        TransactionModel transactionModel = new()
        {
            Amount = 11,
            CoinId = 1,
            SenderId = 1,
            ReceiverWalletAddress = "0987654321"
        };

        string expectedErrorMsg = "Insufficient funds to complete this transaction.";

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient
            .PostAsync("api/transactions", TestUtils.GetJsonHttpContentFrom(transactionModel));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
    }

    [Fact]
    public async Task TestGetTransactionsFromUserOk()
    {
        Context.Users.Add(_testSenderEntity);
        Context.Users.Add(_testReceiverEntity);
        await Context.CoinAccounts.AddRangeAsync(
            new CoinAccount
            {
                Id = 1,
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                Id = 2,
                CoinId = 1,
                Balance = 10,
                UserId = 2
            });
        await Context.Transactions.AddAsync(_testTransactionEntity);
        await Context.SaveChangesAsync();

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.GetAsync($"api/transactions?userid={1}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseTransactions = await response.Content.ReadFromJsonAsync<IEnumerable<Transaction>>();
        Assert.NotNull(responseTransactions);
        Assert.Single(responseTransactions);
    }

    [Fact]
    public async Task TestGetTransactionsFromWrongUser()
    {
        Context.Users.Add(_testSenderEntity);
        Context.Users.Add(_testReceiverEntity);
        await Context.CoinAccounts.AddRangeAsync(
            new CoinAccount
            {
                Id = 1,
                CoinId = 1,
                Balance = 10,
                UserId = 1
            },
            new CoinAccount
            {
                Id = 2,
                CoinId = 1,
                Balance = 10,
                UserId = 2
            });
        await Context.Transactions.AddAsync(_testTransactionEntity);
        await Context.SaveChangesAsync();

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("1234-5678-90");
        var response = await HttpClient.GetAsync($"api/transactions?userid={2}");

        string expectedErrorMsg = "{\"message\":\"Header 'Authorization' expired or invalid.\"}";
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Equal(expectedErrorMsg, (await response.Content.ReadAsStringAsync()));
    }
}