using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebApi.Tests;

public static class TestUtils
{
    public static HttpContent GetJsonHttpContentFrom<T>(T data)
    {
        var payload = JsonConvert.SerializeObject(data);
        return new StringContent(payload, Encoding.UTF8, "application/json");
    }
}