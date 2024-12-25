using Essensoft.Paylinks.Security;

namespace Essensoft.Paylinks.WeChatPay.Core;

/// <summary>
/// WeChatPay 签名类
/// </summary>
public static class WeChatPaySignature
{
    private static string BuildMessage(string method, string url, string timestamp, string nonce, string? body)
    {
        return $"{method}\n{url}\n{timestamp}\n{nonce}\n{body}\n";
    }

    public static string BuildToken(string url, string method, string? body, string mchId, string serialNo, string privateKey)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        var nonce = Guid.NewGuid().ToString("N");
        var message = BuildMessage(method, url, timestamp, nonce, body);
        var signature = SHA256WithRSA.Sign(message, privateKey);

        return $"mchid=\"{mchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{serialNo}\",signature=\"{signature}\"";
    }

    public static string BuildAuthorization(string signatureType, string token)
    {
        return $"{signatureType} {token}";
    }

    public static string BuildSignatureSourceData(string timestamp, string nonce, string body)
    {
        return $"{timestamp}\n{nonce}\n{body}\n";
    }

    public static void VerifySignature(WeChatPayHeaders headers, string body, string wechatpayPublicKey)
    {
        headers.CheckHeaders();

        if (headers.SignatureType == WeChatPaySignatureTypes.WECHATPAY2_SHA256_RSA2048)
        {
            var signatureSourceData = BuildSignatureSourceData(headers.Timestamp, headers.Nonce, body);
            if (!SHA256WithRSA.Verify(signatureSourceData, headers.Signature, wechatpayPublicKey))
            {
                throw new WeChatPayException("验签失败");
            }
        }
        else
        {
            throw new WeChatPayException("不支持该签名算法: " + headers.SignatureType);
        }
    }
}
