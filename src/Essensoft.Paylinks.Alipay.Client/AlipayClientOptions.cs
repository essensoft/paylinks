namespace Essensoft.Paylinks.Alipay.Client;

/// <summary>
/// Alipay 客户端选项
/// </summary>
public class AlipayClientOptions
{
    /// <summary>
    /// 网关地址: https://openapi.alipay.com
    /// </summary>
    public string ServerUrl { get; set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 应用私钥(PKCS#1)
    /// </summary>
    public string AppPrivateKey { get; set; }

    /// <summary>
    /// 应用证书序列号
    /// </summary>
    public string? AppCertSN { get; set; }

    /// <summary>
    /// 支付宝公钥
    /// </summary>
    public string AlipayPublicKey { get; set; }

    /// <summary>
    /// 支付宝证书序列号
    /// </summary>
    public string? AlipayCertSN { get; set; }

    /// <summary>
    /// 支付宝根证书序列号
    /// </summary>
    public string? AlipayRootCertSN { get; set; }

    /// <summary>
    /// 敏感信息对称加密算法类型，推荐：AES
    /// </summary>
    public string? EncryptType { get; set; }

    /// <summary>
    /// 敏感信息对称加密算法密钥
    /// </summary>
    public string? EncryptKey { get; set; }
}
