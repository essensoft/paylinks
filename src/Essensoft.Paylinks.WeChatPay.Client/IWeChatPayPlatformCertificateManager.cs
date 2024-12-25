using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 平台证书管理器
/// </summary>
public interface IWeChatPayPlatformCertificateManager
{
    bool Add(WeChatPayPlatformCertificate cert);

    bool Remove(string serialNo);

    WeChatPayPlatformCertificate? GetBySerialNo(string serialNo);

    IEnumerable<WeChatPayPlatformCertificate> GetAvailableCertificates();

    void RemoveUnavailableCertificates();
}
