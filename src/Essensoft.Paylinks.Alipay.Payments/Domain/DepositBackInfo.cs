using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class DepositBackInfo
{
    /// <summary>
    /// 银行响应时间，格式为yyyy-MM-dd HH:mm:ss
    /// </summary>
    [JsonPropertyName("bank_ack_time")]
    public string BankAckTime { get; set; }

    /// <summary>
    /// 银行卡冲退金额。单位：元。
    /// </summary>
    [JsonPropertyName("dback_amount")]
    public string DbackAmount { get; set; }

    /// <summary>
    /// 银行卡冲退状态。S-成功，F-失败，P-处理中。银行卡冲退失败，资金自动转入用户支付宝余额。
    /// </summary>
    [JsonPropertyName("dback_status")]
    public string DbackStatus { get; set; }

    /// <summary>
    /// 预估银行到账时间，格式为yyyy-MM-dd HH:mm:ss
    /// </summary>
    [JsonPropertyName("est_bank_receipt_time")]
    public string EstBankReceiptTime { get; set; }

    /// <summary>
    /// 是否存在银行卡冲退信息。
    /// </summary>
    [JsonPropertyName("has_deposit_back")]
    public string HasDepositBack { get; set; }
}
