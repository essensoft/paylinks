namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 平台证书管理器工厂
/// </summary>
public interface IWeChatPayPlatformCertificateManagerFactory
{
    /// <summary>
    /// 创建 WeChatPay 平台证书管理器
    /// </summary>
    /// <param name="mchId"></param>
    IWeChatPayPlatformCertificateManager Create(string mchId);
}
