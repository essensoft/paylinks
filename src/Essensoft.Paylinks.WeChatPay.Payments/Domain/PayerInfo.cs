using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

public class PayerInfo
{
    /// <summary>
    /// 用户标识
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }
}
