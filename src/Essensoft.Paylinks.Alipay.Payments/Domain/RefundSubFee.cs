using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class RefundSubFee
{
    /// <summary>
    /// 实退费用。单位：元。
    /// </summary>
    [JsonPropertyName("refund_charge_fee")]
    public string RefundChargeFee { get; set; }

    /// <summary>
    /// 签约费率
    /// </summary>
    [JsonPropertyName("switch_fee_rate")]
    public string SwitchFeeRate { get; set; }
}
