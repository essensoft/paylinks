using System.Collections.Concurrent;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 内存平台证书管理器
/// </summary>
public class WeChatPayInMemoryPlatformCertificateManager : IWeChatPayPlatformCertificateManager
{
    private readonly ConcurrentDictionary<string, WeChatPayPlatformCertificate> _dict = new(StringComparer.OrdinalIgnoreCase);

    public bool Add(WeChatPayPlatformCertificate cert)
    {
        return _dict.TryAdd(cert.SerialNo, cert);
    }

    public bool Remove(string serialNo)
    {
        return _dict.TryRemove(serialNo, out _);
    }

    public WeChatPayPlatformCertificate? GetBySerialNo(string serialNo)
    {
        if (_dict.TryGetValue(serialNo, out var cert))
        {
            if (cert.IsAvailable())
            {
                return cert;
            }

            _dict.TryRemove(serialNo, out _);
        }

        return null;
    }

    public IEnumerable<WeChatPayPlatformCertificate> GetAvailableCertificates()
    {
        return _dict.Values.Where(c => c.IsAvailable()).ToArray();
    }

    public void RemoveUnavailableCertificates()
    {
        foreach (var cert in _dict.Values.Where(c => !c.IsAvailable()).ToArray())
        {
            _dict.TryRemove(cert.SerialNo, out _);
        }
    }
}
