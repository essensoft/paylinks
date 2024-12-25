using System.Text;
using Essensoft.Paylinks.Security;

namespace Essensoft.Paylinks.Alipay.Core;

public static class AlipaySignature
{
    private static string BuildAuthString(string appId, string? appCertSN)
    {
        var nonce = Guid.NewGuid().ToString("N");
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        return $"app_id={appId}{(string.IsNullOrEmpty(appCertSN) ? string.Empty : $",app_cert_sn={appCertSN}=")},nonce={nonce},timestamp={timestamp}";
    }

    private static string BuildMessage(string authString, string httpMethod, string httpRequestUri, string? httpRequestBody, string? appAuthToken)
    {
        return $"{authString}\n{httpMethod}\n{httpRequestUri}\n{(string.IsNullOrEmpty(httpRequestBody) ? string.Empty : httpRequestBody)}\n{(string.IsNullOrEmpty(appAuthToken) ? string.Empty : $"{appAuthToken}\n")}";
    }

    public static string BuildToken(string appId, string? appCertSN, string httpMethod, string httpRequestUri, string? httpRequestBody, string? appAuthToken, string privateKey)
    {
        var authString = BuildAuthString(appId, appCertSN);
        var message = BuildMessage(authString, httpMethod, httpRequestUri, httpRequestBody, appAuthToken);
        var sign = SHA256WithRSA.Sign(message, privateKey);
        return $"{authString},sign={sign}";
    }

    public static string BuildAuthorization(string signatureType, string token)
    {
        return $"{signatureType} {token}";
    }

    public static string BuildSignatureSourceData(string timestamp, string nonce, string body)
    {
        return $"{timestamp}\n{nonce}\n{body}\n";
    }

    public static string BuildSignatureSourceData(IDictionary<string, string> dict)
    {
        var sb = new StringBuilder();
        var sortDict = new SortedDictionary<string, string>(dict);
        foreach (var iter in sortDict)
        {
            if (!string.IsNullOrEmpty(iter.Value))
            {
                sb.Append(iter.Key).Append('=').Append(iter.Value).Append('&');
            }
        }

        return sb.Length > 0 ? sb.ToString()[..^1] : string.Empty;
    }

    public static void VerifySignatureV1(IDictionary<string, string> dict, string alipayPublicKey)
    {
        if (!dict.Remove(AlipayConstants.Sign, out var sign))
        {
            throw new AlipayException($"验签参数: {AlipayConstants.Sign} 为空");
        }

        if (!dict.Remove(AlipayConstants.SignType, out var signType))
        {
            throw new AlipayException($"验签参数: {AlipayConstants.SignType} 为空");
        }

        if (signType.Equals("RSA2", StringComparison.OrdinalIgnoreCase))
        {
            var signatureSourceData = BuildSignatureSourceData(dict);
            if (!SHA256WithRSA.Verify(signatureSourceData, sign, alipayPublicKey))
            {
                throw new AlipayException("验签失败");
            }
        }
        else
        {
            throw new AlipayException($"验签失败: 不支持该签名算法: {signType}");
        }
    }

    public static void VerifySignatureV2(AlipayHeaders headers, string body, string? alipayCertSN, string alipayPublicKey)
    {
        headers.CheckHeaders();

        if (!string.IsNullOrEmpty(headers.SN))
        {
            if (headers.SN != alipayCertSN)
            {
                throw new AlipayException("验签失败: 支付宝证书序列号不一致");
            }
        }

        // 验签
        var signatureSourceData = BuildSignatureSourceData(headers.Timestamp, headers.Nonce, body);
        if (!SHA256WithRSA.Verify(signatureSourceData, headers.Signature, alipayPublicKey))
        {
            throw new AlipayException("验签失败");
        }
    }
}
