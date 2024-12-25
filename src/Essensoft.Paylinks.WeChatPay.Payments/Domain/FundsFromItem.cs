using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 退款出资账户及金额
/// </summary>
public class FundsFromItem
{
    /// <summary>
    /// 出资账户类型
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }

    /// <summary>
    /// 出资金额
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}
