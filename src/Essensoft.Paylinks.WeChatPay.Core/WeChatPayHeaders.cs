namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 应答、通知的头部信息
/// </summary>
/// <para>
/// 如何验证签名
/// https://pay.weixin.qq.com/docs/merchant/development/interface-rules/signature-verification.html
/// </para>
[Serializable]
public class WeChatPayHeaders(string requestId, string serial, string timestamp, string nonce, string signature, string signatureType)
{
    /// <summary>
    /// 平台证书序列号
    /// </summary>
    public string RequestId { get; set; } = requestId;

    /// <summary>
    /// 平台证书序列号
    /// </summary>
    public string Serial { get; set; } = serial;

    /// <summary>
    /// 时间戳
    /// </summary>
    public string Timestamp { get; set; } = timestamp;

    /// <summary>
    /// 随机串
    /// </summary>
    public string Nonce { get; set; } = nonce;

    /// <summary>
    /// 签名串
    /// </summary>
    public string Signature { get; set; } = signature;

    /// <summary>
    /// 签名算法
    /// </summary>
    public string SignatureType { get; set; } = signatureType;

    public void CheckHeaders()
    {
        if (string.IsNullOrEmpty(Serial))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPaySerial} 为空");
        }

        if (string.IsNullOrEmpty(Timestamp))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPayTimestamp} 为空");
        }

        if (string.IsNullOrEmpty(Nonce))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPayNonce} 为空");
        }

        if (string.IsNullOrEmpty(Signature))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPaySignature} 为空");
        }

        if (string.IsNullOrEmpty(SignatureType))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPaySignatureType} 为空");
        }

        if (!long.TryParse(Timestamp, out var timestamp))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPayTimestamp} 无效");
        }

        var timeDifference = DateTimeOffset.Now - DateTimeOffset.FromUnixTimeSeconds(timestamp);
        if (timeDifference.Duration() > TimeSpan.FromMinutes(5))
        {
            throw new WeChatPayException($"头部参数: {WeChatPayHeaderNames.WeChatPayTimestamp} 与当前系统的时差过大");
        }
    }
}
