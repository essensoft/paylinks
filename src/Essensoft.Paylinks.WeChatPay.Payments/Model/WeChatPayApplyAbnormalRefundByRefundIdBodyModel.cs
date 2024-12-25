using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Core;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayApplyAbnormalRefundByRefundIdBodyModel
{
    /// <summary>
    /// 商户退款单号
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; }

    /// <summary>
    /// 异常退款处理方式
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// 开户银行
    /// </summary>
    [JsonPropertyName("bank_type")]
    public string? BankType { get; set; }

    /// <summary>
    /// 收款银行卡号
    /// </summary>
    [WeChatPaySecretProperty]
    [JsonPropertyName("bank_account")]
    public string? BankAccount { get; set; }

    /// <summary>
    /// 收款用户姓名
    /// </summary>
    [WeChatPaySecretProperty]
    [JsonPropertyName("real_name")]
    public string? RealName { get; set; }
}
