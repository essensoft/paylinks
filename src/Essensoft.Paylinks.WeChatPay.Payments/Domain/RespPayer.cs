using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 支付者
/// </summary>
public class RespPayer
{
    /// <summary>
    /// 用户标识
    /// </summary>
    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }
}
