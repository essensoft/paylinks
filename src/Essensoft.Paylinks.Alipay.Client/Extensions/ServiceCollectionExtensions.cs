using Microsoft.Extensions.DependencyInjection;

namespace Essensoft.Paylinks.Alipay.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddAlipayClient(this IServiceCollection services, int timeout = 15)
    {
        return services.AddAlipayClient(httpClient =>
        {
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
        });
    }

    public static IHttpClientBuilder AddAlipayClient(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddSingleton<IAlipayClient, AlipayClient>();
        services.AddSingleton<IAlipayNotifyClient, AlipayNotifyClient>();
        return services.AddHttpClient(AlipayClient.HttpClientName, configureClient);
    }
}
