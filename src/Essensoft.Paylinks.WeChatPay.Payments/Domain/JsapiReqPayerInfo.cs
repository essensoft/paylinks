using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 支付者信息
/// </summary>
public class JsapiReqPayerInfo
{
    /// <summary>
    /// 用户标识
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }
}
