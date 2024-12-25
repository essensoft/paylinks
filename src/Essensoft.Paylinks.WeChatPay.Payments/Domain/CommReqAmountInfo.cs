using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 订单金额
/// </summary>
public class CommReqAmountInfo
{
    /// <summary>
    /// 总金额
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 货币类型
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}
