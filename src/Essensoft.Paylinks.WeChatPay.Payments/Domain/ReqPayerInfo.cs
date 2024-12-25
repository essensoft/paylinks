using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class ReqPayerInfo
{
    /// <summary>
    /// 用户标识
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }
}
