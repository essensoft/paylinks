namespace Essensoft.Paylinks.Alipay.Payments.Domain;

/// <summary>
/// Alipay 交易状态
/// </summary>
public static class AlipayTradeStatus
{
    /// <summary>
    /// 交易创建，等待买家付款
    /// </summary>
    public const string WaitBuyerPay = "WAIT_BUYER_PAY";

    /// <summary>
    /// 未付款交易超时关闭，或支付完成后全额退款
    /// </summary>
    public const string TradeClosed = "TRADE_CLOSED";

    /// <summary>
    /// 交易支付成功，可退款
    /// </summary>
    public const string TradeSuccess = "TRADE_SUCCESS";

    /// <summary>
    /// 交易结束，不可退款
    /// </summary>
    public const string TradeFinished = "TRADE_FINISHED";
}
