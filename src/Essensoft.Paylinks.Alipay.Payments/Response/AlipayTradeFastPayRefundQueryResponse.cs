using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Response;

public class AlipayTradeFastPayRefundQueryResponse : AlipayResponse
{
    /// <summary>
    /// 支付宝交易号
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string? OutTradeNo { get; set; }

    /// <summary>
    /// 本笔退款对应的退款请求号
    /// </summary>
    [JsonPropertyName("out_request_no")]
    public string? OutRequestNo { get; set; }

    /// <summary>
    /// 该笔退款所对应的交易的订单金额。单位：元。
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string? TotalAmount { get; set; }

    /// <summary>
    /// 本次退款请求，对应的退款金额。单位：元。
    /// </summary>
    [JsonPropertyName("refund_amount")]
    public string? RefundAmount { get; set; }

    /// <summary>
    /// 退款状态。枚举值：REFUND_SUCCESS 退款处理成功； 未返回该字段表示退款请求未收到或者退款失败； 注：如果退款查询发起时间早于退款时间，或者间隔退款发起时间太短，可能出现退款查询时还没处理成功，后面又处理成功的情况，建议商户在退款发起后间隔10秒以上再发起退款查询请求。
    /// </summary>
    [JsonPropertyName("refund_status")]
    public string? RefundStatus { get; set; }

    /// <summary>
    /// 退分账明细信息，当前仅在直付通产品中返回。
    /// </summary>
    [JsonPropertyName("refund_royaltys")]
    public List<RefundRoyaltyResult>? RefundRoyaltys { get; set; }

    /// <summary>
    /// 退款时间。默认不返回该信息，需要在入参的query_options中指定"gmt_refund_pay"值时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("gmt_refund_pay")]
    public DateTimeOffset? GmtRefundPay { get; set; }

    /// <summary>
    /// 本次退款使用的资金渠道； 默认不返回该信息，需要在入参的query_options中指定"refund_detail_item_list"值时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("refund_detail_item_list")]
    public List<TradeFundBill>? RefundDetailItemList { get; set; }

    /// <summary>
    /// 本次商户实际退回金额；单位：元。 默认不返回该信息，需要在入参的query_options中指定"refund_detail_item_list"值时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("send_back_fee")]
    public string? SendBackFee { get; set; }

    /// <summary>
    /// 银行卡冲退信息； 默认不返回该信息，需要在入参的query_options中指定"deposit_back_info"值时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("deposit_back_info")]
    public DepositBackInfo? DepositBackInfo { get; set; }

    /// <summary>
    /// 本交易支付时使用的所有优惠券信息。 只有在query_options中指定refund_voucher_detail_list时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("refund_voucher_detail_list")]
    public List<VoucherDetail>? RefundVoucherDetailList { get; set; }

    /// <summary>
    /// 本次退款金额中退惠营宝的金额。单位：元。
    /// </summary>
    [JsonPropertyName("refund_hyb_amount")]
    public string? RefundHybAmount { get; set; }

    /// <summary>
    /// 退费信息
    /// </summary>
    [JsonPropertyName("refund_charge_info_list")]
    public List<RefundChargeInfo>? RefundChargeInfoList { get; set; }

    /// <summary>
    /// 银行卡冲退信息列表。 默认不返回该信息，需要在入参的query_options中指定"deposit_back_info_list"值时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("deposit_back_info_list")]
    public List<DepositBackInfo>? DepositBackInfoList { get; set; }
}
