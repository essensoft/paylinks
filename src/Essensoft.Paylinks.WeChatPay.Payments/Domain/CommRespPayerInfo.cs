using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class CommRespPayerInfo
{
    /// <summary>
    /// 用户标识
    /// 用户在应用AppID下的唯一标识。
    /// </summary>
    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }
}
