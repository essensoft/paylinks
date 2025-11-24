using Microsoft.Extensions.DependencyInjection;

namespace Essensoft.Paylinks.WeChatPay.Client.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IHttpClientBuilder AddWeChatPayClient(int timeout = 15)
        {
            return services.AddWeChatPayClient(httpClient =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            });
        }

        public IHttpClientBuilder AddWeChatPayClient(Action<HttpClient> configureClient)
        {
            services.AddSingleton<IWeChatPayPlatformCertificateManagerFactory, WeChatPayInMemoryPlatformCertificateManagerFactory>();
            services.AddSingleton<IWeChatPayClient, WeChatPayClient>();
            services.AddSingleton<IWeChatPayNotifyClient, WeChatPayNotifyClient>();
            return services.AddHttpClient(WeChatPayClient.HttpClientName, configureClient);
        }
    }
}
