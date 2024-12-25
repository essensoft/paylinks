// ReSharper disable InconsistentNaming

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 客户端选项
/// </summary>
public class WeChatPayClientOptions
{
    /// <summary>
    /// 网关地址: https://api.mch.weixin.qq.com
    /// </summary>
    public string ServerUrl { get; set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 商户号
    /// </summary>
    public string MchId { get; set; }

    /// <summary>
    /// 商户证书序列号
    /// </summary>
    public string MchSerialNo { get; set; }

    /// <summary>
    /// 商户证书私钥
    /// </summary>
    public string MchPrivateKey { get; set; }

    /// <summary>
    /// 微信支付公钥
    /// </summary>
    public string? WeChatPayPublicKey { get; set; }

    /// <summary>
    /// 微信支付公钥Id(公钥序列号)
    /// </summary>
    public string? WeChatPayPublicKeyId { get; set; }

    /// <summary>
    /// 商户APIv3密钥
    /// </summary>
    public string APIv3Key { get; set; }
}
