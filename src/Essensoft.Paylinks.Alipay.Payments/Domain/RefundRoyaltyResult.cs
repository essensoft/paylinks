using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class RefundRoyaltyResult
{
    /// <summary>
    /// 商户请求的转入账号
    /// </summary>
    [JsonPropertyName("ori_trans_in")]
    public string OriTransIn { get; set; }

    /// <summary>
    /// 商户请求的转出账号
    /// </summary>
    [JsonPropertyName("ori_trans_out")]
    public string OriTransOut { get; set; }

    /// <summary>
    /// 退分账金额。单位：元。
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public string RefundAmount { get; set; }

    /// <summary>
    /// 退分账结果码
    /// </summary>
    [JsonPropertyName("result_code")]
    public string ResultCode { get; set; }

    /// <summary>
    /// 分账类型. 字段为空默认为普通分账类型transfer
    /// </summary>
    [JsonPropertyName("royalty_type")]
    public string RoyaltyType { get; set; }

    /// <summary>
    /// 转入人支付宝账号对应用户ID
    /// </summary>
    [JsonPropertyName("trans_in")]
    public string TransIn { get; set; }

    /// <summary>
    /// 转入人支付宝账号
    /// </summary>
    [JsonPropertyName("trans_in_email")]
    public string TransInEmail { get; set; }

    /// <summary>
    /// 转出人支付宝账号对应用户ID
    /// </summary>
    [JsonPropertyName("trans_out")]
    public string TransOut { get; set; }

    /// <summary>
    /// 转出人支付宝账号
    /// </summary>
    [JsonPropertyName("trans_out_email")]
    public string TransOutEmail { get; set; }
}
