using System.Collections.Concurrent;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 内存平台证书管理器工厂
/// </summary>
public class WeChatPayInMemoryPlatformCertificateManagerFactory : IWeChatPayPlatformCertificateManagerFactory
{
    private readonly ConcurrentDictionary<string, IWeChatPayPlatformCertificateManager> _dict = new();

    public IWeChatPayPlatformCertificateManager Create(string mchId)
    {
        return _dict.GetOrAdd(mchId, new WeChatPayInMemoryPlatformCertificateManager());
    }
}
