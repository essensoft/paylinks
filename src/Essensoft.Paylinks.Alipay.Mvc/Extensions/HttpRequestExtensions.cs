using Microsoft.AspNetCore.Http;

namespace Essensoft.Paylinks.Alipay.Mvc.Extensions;

public static class HttpRequestExtensions
{
    public static async Task<Dictionary<string, string>> GetAlipayParametersAsync(this HttpRequest request)
    {
        var parameters = new Dictionary<string, string>();
        if (request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
        {
            foreach (var iter in await request.ReadFormAsync().ConfigureAwait(false))
            {
                parameters.Add(iter.Key, iter.Value.ToString());
            }
        }
        else if (request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
        {
            foreach (var iter in request.Query)
            {
                parameters.Add(iter.Key, iter.Value.ToString());
            }
        }

        return parameters;
    }
}
