// ReSharper disable InconsistentNaming

namespace Essensoft.Paylinks.Alipay.Core;

public class AlipayHeaders
{
    /// <summary>
    /// unix时间戳，用于验签及问题排查，参考验签规则。在header参数中传递
    /// </summary>
    public string Timestamp { get; set; }

    /// <summary>
    /// 支付宝响应报文签名，参考验签规则。在header中返回
    /// </summary>
    public string Signature { get; set; }

    /// <summary>
    /// 支付宝使用的证书号
    /// </summary>
    public string SN { get; set; }

    /// <summary>
    /// 支付宝traceId ，用于排查问题使用，参考请求规则。在header中返回
    /// </summary>
    public string TraceId { get; set; }

    /// <summary>
    /// 支付宝nonce标记，每次请求会生成不同的nonce，可用于防重放判断，参考请求规则。在header中返回
    /// </summary>
    public string Nonce { get; set; }

    public AlipayHeaders(string timestamp, string signature, string sn, string traceId, string nonce)
    {
        Timestamp = timestamp;
        Signature = signature;
        SN = sn;
        TraceId = traceId;
        Nonce = nonce;
    }

    public void CheckHeaders()
    {
        if (string.IsNullOrEmpty(Timestamp))
        {
            throw new AlipayException($"头部参数: {AlipayHeaderNames.AlipayTimestamp} 为空");
        }

        if (string.IsNullOrEmpty(Signature))
        {
            throw new AlipayException($"头部参数: {AlipayHeaderNames.AlipaySignature} 为空");
        }

        if (string.IsNullOrEmpty(Nonce))
        {
            throw new AlipayException($"头部参数: {AlipayHeaderNames.AlipayNonce} 为空");
        }

        if (!long.TryParse(Timestamp, out var timestamp))
        {
            throw new AlipayException($"头部参数: {AlipayHeaderNames.AlipayTimestamp} 无效");
        }

        var timeDifference = DateTimeOffset.Now - DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
        if (timeDifference.Duration() > TimeSpan.FromMinutes(5))
        {
            throw new AlipayException($"头部参数: {AlipayHeaderNames.AlipayTimestamp} 与当前系统的时差过大");
        }
    }
}
