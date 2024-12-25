using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Notify;

/// <summary>
/// 异步通知
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/05pf4k?pathHash=01c6e762
/// 异步通知说明
/// 更新时间：2024-07-16 18:19:31
/// </para>
public class AlipayTradeStatusSyncNotify : IAlipayNotify
{
    /// <summary>
    /// 通知时间
    /// </summary>
    [JsonPropertyName("notify_time")]
    public DateTimeOffset NotifyTime { get; set; }

    /// <summary>
    /// 通知类型
    /// </summary>
    [JsonPropertyName("notify_type")]
    public string NotifyType { get; set; }

    /// <summary>
    /// 通知校验ID
    /// </summary>
    [JsonPropertyName("notify_id")]
    public string NotifyId { get; set; }

    /// <summary>
    /// 签名类型
    /// </summary>
    [JsonPropertyName("sign_type")]
    public string SignType { get; set; }

    /// <summary>
    /// 签名
    /// </summary>
    [JsonPropertyName("sign")]
    public string Sign { get; set; }

    /// <summary>
    /// 支付宝交易号
    /// </summary>
    [JsonPropertyName("trade_no")]
    public string TradeNo { get; set; }

    /// <summary>
    /// 开发者的app_id
    /// </summary>
    [JsonPropertyName("app_id")]
    public string AppId { get; set; }

    /// <summary>
    /// 开发者的 app_id，在服务商调用的场景下为授权方的 app_id。
    /// </summary>
    [JsonPropertyName("auth_app_id")]
    public string AuthAppId { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 商户业务号
    /// </summary>
    [JsonPropertyName("out_biz_no")]
    public string OutBizNo { get; set; }

    /// <summary>
    /// 买家支付宝用户号
    /// </summary>
    [JsonPropertyName("buyer_id")]
    public string BuyerId { get; set; }

    /// <summary>
    /// 买家支付宝账号
    /// </summary>
    [JsonPropertyName("buyer_logon_id")]
    public string BuyerLogonId { get; set; }

    /// <summary>
    /// 卖家支付宝用户号
    /// </summary>
    [JsonPropertyName("seller_id")]
    public string SellerId { get; set; }

    /// <summary>
    /// 卖家支付宝账号
    /// </summary>
    [JsonPropertyName("seller_email")]
    public string SellerEmail { get; set; }

    /// <summary>
    /// 交易状态
    /// </summary>
    [JsonPropertyName("trade_status")]
    public string TradeStatus { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string TotalAmount { get; set; }

    /// <summary>
    /// 实收金额
    /// </summary>
    [JsonPropertyName("receipt_amount")]
    public string ReceiptAmount { get; set; }

    /// <summary>
    /// 开票金额
    /// </summary>
    [JsonPropertyName("invoice_amount")]
    public string InvoiceAmount { get; set; }

    /// <summary>
    /// 付款金额
    /// </summary>
    [JsonPropertyName("buyer_pay_amount")]
    public string BuyerPayAmount { get; set; }

    /// <summary>
    /// 集分宝金额
    /// </summary>
    [JsonPropertyName("point_amount")]
    public string PointAmount { get; set; }

    /// <summary>
    /// 总退款金额
    /// </summary>
    [JsonPropertyName("refund_fee")]
    public string RefundFee { get; set; }

    /// <summary>
    /// 实际退款金额
    /// </summary>
    [JsonPropertyName("send_back_fee")]
    public string SendBackFee { get; set; }

    /// <summary>
    /// 订单标题
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// 商品描述
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; set; }

    /// <summary>
    /// 交易创建时间
    /// </summary>
    [JsonPropertyName("gmt_create")]
    public DateTimeOffset GmtCreate { get; set; }

    /// <summary>
    /// 交易付款时间
    /// </summary>
    [JsonPropertyName("gmt_payment")]
    public DateTimeOffset GmtPayment { get; set; }

    /// <summary>
    /// 交易退款时间
    /// </summary>
    [JsonPropertyName("gmt_refund")]
    public DateTimeOffset GmtRefund { get; set; }

    /// <summary>
    /// 交易结束时间
    /// </summary>
    [JsonPropertyName("gmt_close")]
    public DateTimeOffset GmtClose { get; set; }

    /// <summary>
    /// 支付金额信息
    /// </summary>
    [JsonPropertyName("fund_bill_list")]
    public string FundBillList { get; set; }

    /// <summary>
    /// 优惠券信息
    /// </summary>
    [JsonPropertyName("voucher_detail_list")]
    public string VoucherDetailList { get; set; }

    /// <summary>
    /// 账期结算标识，指已完成支付的订单会进行账期管控，不会实时结算。该参数目前会在使用小程序交易组件场景下返回。
    /// </summary>
    [JsonPropertyName("biz_settle_mode")]
    public string BizSettleMode { get; set; }
}
