using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Response;

public class AlipayTradePayResponse : AlipayResponse
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
    /// 买家支付宝账号
    /// </summary>
    [JsonPropertyName("buyer_logon_id")]
    public string BuyerLogonId { get; set; }

    /// <summary>
    /// 交易金额
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string TotalAmount { get; set; }

    /// <summary>
    /// 实收金额
    /// </summary>
    [JsonPropertyName("receipt_amount")]
    public string ReceiptAmount { get; set; }

    /// <summary>
    /// 交易支付时间
    /// </summary>
    [JsonPropertyName("gmt_payment")]
    public DateTimeOffset GmtPayment { get; set; }

    /// <summary>
    /// 交易支付使用的资金渠道。 只有在签约中指定需要返回资金明细，或者入参的query_options中指定时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("fund_bill_list")]
    public List<TradeFundBill> FundBillList { get; set; }

    /// <summary>
    /// 买家在支付宝的用户id
    /// </summary>
    [JsonPropertyName("buyer_user_id")]
    public string? BuyerUserId { get; set; }

    /// <summary>
    /// 买家支付宝用户唯一标识
    /// </summary>
    [JsonPropertyName("buyer_open_id")]
    public string? BuyerOpenId { get; set; }

    /// <summary>
    /// 商家优惠金额
    /// </summary>
    [JsonPropertyName("mdiscount_amount")]
    public string? MDiscountAmount { get; set; }

    /// <summary>
    /// 平台优惠金额
    /// </summary>
    [JsonPropertyName("discount_amount")]
    public string? DiscountAmount { get; set; }

    /// <summary>
    /// 买家付款的金额
    /// </summary>
    [JsonPropertyName("buyer_pay_amount")]
    public string? BuyerPayAmount { get; set; }

    /// <summary>
    /// 使用集分宝付款的金额
    /// </summary>
    [JsonPropertyName("point_amount")]
    public string? PointAmount { get; set; }

    /// <summary>
    /// 交易中可给用户开具发票的金额
    /// </summary>
    [JsonPropertyName("invoice_amount")]
    public string? InvoiceAmount { get; set; }

    /// <summary>
    /// 发生支付交易的商户门店名称
    /// </summary>
    [JsonPropertyName("store_name")]
    public string? StoreName { get; set; }

    /// <summary>
    /// 本次交易支付所使用的单品券优惠的商品优惠信息。 只有在query_options中指定时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("discount_goods_detail")]
    public string? DiscountGoodsDetail { get; set; }

    /// <summary>
    /// 本交易支付时使用的所有优惠券信息。 只有在query_options中指定时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("voucher_detail_list")]
    public List<VoucherDetail>? VoucherDetailList { get; set; }
}
