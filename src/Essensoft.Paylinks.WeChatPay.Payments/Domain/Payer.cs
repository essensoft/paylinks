using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 支付者信息
/// </summary>
public class Payer
{
    /// <summary>
    /// 授权码
    /// </summary>
    [JsonPropertyName("auth_code")]
    public string AuthCode { get; set; }
}
