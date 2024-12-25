using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Response;

public class AlipayTradeRefundResponse : AlipayResponse
{
    /// <summary>
    /// 支付宝交易号
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string TradeNo { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 用户的登录id
    /// </summary>
    [JsonPropertyName("buyer_logon_id")]
    public string BuyerLogonId { get; set; }

    /// <summary>
    /// 退款总金额。单位：元。 指该笔交易累计已经退款成功的金额。
    /// </summary>
    [JsonPropertyName("refund_fee")]
    public string RefundFee { get; set; }

    /// <summary>
    /// 退款使用的资金渠道。 只有在签约中指定需要返回资金明细，或者入参的query_options中指定时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("refund_detail_item_list")]
    public List<TradeFundBill>? RefundDetailItemList { get; set; }

    /// <summary>
    /// 交易在支付时候的门店名称
    /// </summary>
    [JsonPropertyName("store_name")]
    public string? StoreName { get; set; }

    /// <summary>
    /// 买家在支付宝的用户id
    /// </summary>
    [JsonPropertyName("buyer_user_id")]
    public string? BuyerUserId { get; set; }

    /// <summary>
    /// 买家支付宝用户唯一标识  详情可查看 openid简介
    /// </summary>
    [JsonPropertyName("buyer_open_id")]
    public string? BuyerOpenId { get; set; }

    /// <summary>
    /// 本次商户实际退回金额。单位：元。 说明：如需获取该值，需在入参query_options中传入 refund_detail_item_list。
    /// </summary>
    [JsonPropertyName("send_back_fee")]
    public string? SendBackFee { get; set; }

    /// <summary>
    /// 本次退款是否发生了资金变化
    /// </summary>
    [JsonPropertyName("fund_change")]
    public string? FundChange { get; set; }

    /// <summary>
    /// 本次请求退惠营宝金额。单位：元。
    /// </summary>
    [JsonPropertyName("refund_hyb_amount")]
    public string? RefundHybAmount { get; set; }

    /// <summary>
    /// 退费信息
    /// </summary>
    [JsonPropertyName("refund_charge_info_list")]
    public List<RefundChargeInfo>? RefundChargeInfoList { get; set; }

    /// <summary>
    /// 本交易支付时使用的所有优惠券信息。 只有在query_options中指定了refund_voucher_detail_list时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("refund_voucher_detail_list")]
    public List<VoucherDetail>? RefundVoucherDetailList { get; set; }
}
