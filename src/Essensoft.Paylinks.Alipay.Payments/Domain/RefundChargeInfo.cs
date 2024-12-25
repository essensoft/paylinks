using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class RefundChargeInfo
{
    /// <summary>
    /// 收单手续费trade，花呗分期手续hbfq，其他手续费charge
    /// </summary>
    [JsonPropertyName("charge_type")]
    public string ChargeType { get; set; }

    /// <summary>
    /// 实退费用。单位：元。
    /// </summary>
    [JsonPropertyName("refund_charge_fee")]
    public string RefundChargeFee { get; set; }

    /// <summary>
    /// 组合支付退费明细
    /// </summary>
    [JsonPropertyName("refund_sub_fee_detail_list")]
    public List<RefundSubFee> RefundSubFeeDetailList { get; set; }

    /// <summary>
    /// 签约费率
    /// </summary>
    [JsonPropertyName("switch_fee_rate")]
    public string SwitchFeeRate { get; set; }
}
