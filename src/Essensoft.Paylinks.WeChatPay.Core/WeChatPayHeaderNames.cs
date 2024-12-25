namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// 头文件名
/// </summary>
public static class WeChatPayHeaderNames
{
    /// <summary>
    /// 序列号
    /// </summary>
    public const string RequestId = "Request-ID";

    /// <summary>
    /// 序列号
    /// </summary>
    public const string WeChatPaySerial = "Wechatpay-Serial";

    /// <summary>
    /// 时间戳
    /// </summary>
    public const string WeChatPayTimestamp = "Wechatpay-Timestamp";

    /// <summary>
    /// 随机串
    /// </summary>
    public const string WeChatPayNonce = "Wechatpay-Nonce";

    /// <summary>
    /// 签名
    /// </summary>
    public const string WeChatPaySignature = "Wechatpay-Signature";

    /// <summary>
    /// 签名算法
    /// </summary>
    public const string WeChatPaySignatureType = "Wechatpay-Signature-Type";
}
