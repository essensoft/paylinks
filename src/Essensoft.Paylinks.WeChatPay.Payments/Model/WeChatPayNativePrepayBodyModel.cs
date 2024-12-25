using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayNativePrepayBodyModel
{
    /// <summary>
    /// 公众号ID
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 直连商户号
    /// </summary>
    [JsonPropertyName("mchid")]
    public string MchId { get; set; }

    /// <summary>
    /// 商品描述
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 商户订单号
    /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 交易结束时间
    /// 订单失效时间，遵循rfc3339标准格式，格式为yyyy-MM-DDTHH:mm:ss+TIMEZONE，yyyy-MM-DD表示年月日，T出现在字符串中，表示time元素的开头，HH:mm:ss表示时分秒，TIMEZONE表示时区（+08:00表示东八区时间，领先UTC8小时，即北京时间）。例如：2015-05-20T13:29:35+08:00表示，北京时间2015年5月20日13点29分35秒。
    /// </summary>
    [JsonPropertyName("time_expire")]
    public DateTimeOffset? TimeExpire { get; set; }

    /// <summary>
    /// 附加数据
    /// </summary>
    [JsonPropertyName("attach")]
    public string? Attach { get; set; }

    /// <summary>
    /// 通知地址
    /// 异步接收微信支付结果通知的回调地址，通知URL必须为外网可访问的URL，不能携带参数。 公网域名必须为HTTPS，如果是走专线接入，使用专线NAT IP或者私有回调域名可使用HTTP
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; }

    /// <summary>
    /// 订单优惠标记
    /// 商品标记，代金券或立减优惠功能的参数。
    /// </summary>
    [JsonPropertyName("goods_tag")]
    public string? GoodsTag { get; set; }

    /// <summary>
    /// 电子发票入口开放标识
    /// 传入true时，支付成功消息和支付详情页将出现开票入口。需要在微信支付商户平台或微信公众平台开通电子发票功能，传此字段才可生效。
    /// </summary>
    [JsonPropertyName("support_fapiao")]
    public bool? SupportFaPiao { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonPropertyName("amount")]
    public CommReqAmountInfo Amount { get; set; }

    /// <summary>
    /// 优惠功能
    /// </summary>
    [JsonPropertyName("detail")]
    public OrderDetail? Detail { get; set; }

    /// <summary>
    /// 场景信息
    /// </summary>
    [JsonPropertyName("scene_info")]
    public CommReqSceneInfo? SceneInfo { get; set; }

    /// <summary>
    /// 结算信息
    /// </summary>
    [JsonPropertyName("settle_info")]
    public SettleInfo? SettleInfo { get; set; }
}
