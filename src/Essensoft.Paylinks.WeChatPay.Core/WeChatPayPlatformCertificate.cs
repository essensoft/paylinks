using System.Security.Cryptography.X509Certificates;

namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 平台证书
/// </summary>
public class WeChatPayPlatformCertificate(string serialNo, DateTimeOffset? effectiveTime, DateTimeOffset? expireTime, X509Certificate2 certificate, string publicKey)
{
    /// <summary>
    /// 序列号
    /// </summary>
    public string SerialNo { get; set; } = serialNo;

    /// <summary>
    /// 生效时间
    /// </summary>
    public DateTimeOffset? EffectiveTime { get; set; } = effectiveTime;

    /// <summary>
    /// 失效时间
    /// </summary>
    public DateTimeOffset? ExpireTime { get; set; } = expireTime;

    /// <summary>
    /// 证书
    /// </summary>
    public X509Certificate2 Certificate { get; set; } = certificate;

    /// <summary>
    /// 证书公钥
    /// </summary>
    public string PublicKey { get; set; } = publicKey;

    /// <summary>
    /// 是否在有效期内
    /// </summary>
    public bool IsAvailable()
    {
        return DateTimeOffset.Now >= EffectiveTime && ExpireTime > DateTimeOffset.Now;
    }
}
