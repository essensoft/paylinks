using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Certificates.Domain;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Certificates.Response;

public class WeChatPayCertificatesResponse : WeChatPayResponse
{
    /// <summary>
    /// 平台证书的详情
    /// </summary>
    [JsonPropertyName("data")]
    public List<Certificate>? Certificates { get; set; }
}
