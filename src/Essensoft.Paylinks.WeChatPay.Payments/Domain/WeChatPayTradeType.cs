namespace Essensoft.Paylinks.WeChatPay.Payments.Domain;

/// <summary>
/// WeChatPay 交易类型
/// </summary>
public static class WeChatPayTradeType
{
    /// <summary>
    /// 公众号支付
    /// </summary>
    public const string Jsapi = "JSAPI";

    /// <summary>
    /// 扫码支付
    /// </summary>
    public const string Native = "NATIVE";

    /// <summary>
    /// App支付
    /// </summary>
    public const string App = "App";

    /// <summary>
    /// 付款码支付
    /// </summary>
    public const string MicroPay = "MICROPAY";

    /// <summary>
    /// H5支付
    /// </summary>
    public const string MWeb = "MWEB";

    /// <summary>
    /// 刷脸支付
    /// </summary>
    public const string FacePay = "FACEPAY";
}
