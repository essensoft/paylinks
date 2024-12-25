using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;
using Essensoft.Paylinks.Alipay.Payments.Domain;

namespace Essensoft.Paylinks.Alipay.Payments.Response;

public class AlipayTradeQueryResponse : AlipayResponse
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
    /// 交易状态：WAIT_BUYER_PAY（交易创建，等待买家付款）、TRADE_CLOSED（未付款交易超时关闭，或支付完成后全额退款）、TRADE_SUCCESS（交易支付成功）、TRADE_FINISHED（交易结束，不可退款）
    /// </summary>
    [JsonPropertyName("trade_status")]
    public string TradeStatus { get; set; }

    /// <summary>
    /// 交易的订单金额，单位为元，两位小数。该参数的值为支付时传入的total_amount
    /// </summary>
    [JsonPropertyName("total_amount")]
    public string TotalAmount { get; set; }

    /// <summary>
    /// 交易支付使用的资金渠道。 只有在签约中指定需要返回资金明细，或者入参的query_options中指定时才返回该字段信息。
    /// </summary>
    [JsonPropertyName("fund_bill_list")]
    public List<TradeFundBill> FundBillList { get; set; }

    /// <summary>
    /// 买家在支付宝的用户id
    /// </summary>
    [JsonPropertyName("buyer_user_id")]
    public string BuyerUserId { get; set; }

    /// <summary>
    /// 本次交易打款给卖家的时间
    /// </summary>
    [JsonPropertyName("send_pay_date")]
    public DateTimeOffset? SendPayDate { get; set; }

    /// <summary>
    /// 实收金额，单位为元，两位小数。该金额为本笔交易，商户账户能够实际收到的金额
    /// </summary>
    [JsonPropertyName("receipt_amount")]
    public string? ReceiptAmount { get; set; }

    /// <summary>
    /// 商户门店编号
    /// </summary>
    [JsonPropertyName("store_id")]
    public string? StoreId { get; set; }

    /// <summary>
    /// 商户机具终端编号
    /// </summary>
    [JsonPropertyName("terminal_id")]
    public string? TerminalId { get; set; }

    /// <summary>
    /// 请求交易支付中的商户店铺的名称
    /// </summary>
    [JsonPropertyName("store_name")]
    public string? StoreName { get; set; }

    /// <summary>
    /// 买家支付宝用户唯一标识
    /// </summary>
    [JsonPropertyName("buyer_open_id")]
    public string? BuyerOpenId { get; set; }

    /// <summary>
    /// 买家用户类型。CORPORATE:企业用户；PRIVATE:个人用户。
    /// </summary>
    [JsonPropertyName("buyer_user_type")]
    public string? BuyerUserType { get; set; }

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
    /// 交易额外信息，特殊场景下与支付宝约定返回。
    /// json格式。
    /// </summary>
    [JsonPropertyName("ext_infos")]
    public string? ExtInfos { get; set; }

    /// <summary>
    /// 买家实付金额，单位为元，两位小数。该金额代表该笔交易买家实际支付的金额，不包含商户折扣等金额
    /// </summary>
    [JsonPropertyName("buyer_pay_amount")]
    public string? BuyerPayAmount { get; set; }

    /// <summary>
    /// 积分支付的金额，单位为元，两位小数。该金额代表该笔交易中用户使用积分支付的金额，比如集分宝或者支付宝实时优惠等
    /// </summary>
    [JsonPropertyName("point_amount")]
    public string? PointAmount { get; set; }

    /// <summary>
    /// 交易中用户支付的可开具发票的金额，单位为元，两位小数。该金额代表该笔交易中可以给用户开具发票的金额
    /// </summary>
    [JsonPropertyName("invoice_amount")]
    public string? InvoiceAmount { get; set; }
}
