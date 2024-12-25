namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// WeChatPay 支付产品 通知事件类型
/// </summary>
public static class WeChatPayPaymentEventTypes
{
    /// <summary>
    /// 支付成功通知
    /// </summary>
    public const string TransactionSuccess = "TRANSACTION.SUCCESS";

    /// <summary>
    /// 退款成功通知
    /// </summary>
    public const string RefundSuccess = "REFUND.SUCCESS";

    /// <summary>
    /// 退款异常通知
    /// </summary>
    public const string RefundAbnormal = "REFUND.ABNORMAL";

    /// <summary>
    /// 退款关闭通知
    /// </summary>
    public const string RefundClosed = "REFUND.CLOSED";
}
