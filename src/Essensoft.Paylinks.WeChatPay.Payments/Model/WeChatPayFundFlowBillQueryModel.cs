using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

[Obsolete("Use WeChatPayFundFlowBillQueryModel")]
public class WeChatPayGetFundFlowBillQueryModel : WeChatPayFundFlowBillQueryModel;

public class WeChatPayFundFlowBillQueryModel
{
    /// <summary>
    /// 账单日期
    /// </summary>
    [JsonPropertyName("bill_date")]
    public string BillDate { get; set; }

    /// <summary>
    /// 资金账户类型
    /// </summary>
    [JsonPropertyName("account_type")]
    public string? AccountType { get; set; }

    /// <summary>
    /// 压缩类型
    /// </summary>
    [JsonPropertyName("tar_type")]
    public string? TarType { get; set; }
}
