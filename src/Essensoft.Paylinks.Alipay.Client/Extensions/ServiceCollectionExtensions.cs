using Microsoft.Extensions.DependencyInjection;

namespace Essensoft.Paylinks.Alipay.Client.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IHttpClientBuilder AddAlipayClient(int timeout = 15)
        {
            return services.AddAlipayClient(httpClient =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            });
        }

        public IHttpClientBuilder AddAlipayClient(Action<HttpClient> configureClient)
        {
            services.AddSingleton<IAlipayClient, AlipayClient>();
            services.AddSingleton<IAlipayNotifyClient, AlipayNotifyClient>();
            return services.AddHttpClient(AlipayClient.HttpClientName, configureClient);
        }
    }
}
