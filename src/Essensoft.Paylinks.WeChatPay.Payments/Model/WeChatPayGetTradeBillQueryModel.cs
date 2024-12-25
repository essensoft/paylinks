using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayGetTradeBillQueryModel
{
    /// <summary>
    /// 账单日期
    /// </summary>
    [JsonPropertyName("bill_date")]
    public string BillDate { get; set; }

    /// <summary>
    /// 账单类型
    /// </summary>
    [JsonPropertyName("bill_type")]
    public string? BillType { get; set; }

    /// <summary>
    /// 压缩类型
    /// </summary>
    [JsonPropertyName("tar_type")]
    public string? TarType { get; set; }
}
