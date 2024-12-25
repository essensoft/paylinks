using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 预签约结果
/// </summary>
public class ContractResult
{
    /// <summary>
    /// 签约结果码
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 签约结果描述信息
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
