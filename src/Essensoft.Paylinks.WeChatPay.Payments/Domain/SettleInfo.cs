using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// 结算信息
/// </summary>
public class SettleInfo
{
    /// <summary>
    /// 是否指定分账
    /// </summary>
    [JsonPropertyName("profit_sharing")]
    public bool? ProfitSharing { get; set; }
}
