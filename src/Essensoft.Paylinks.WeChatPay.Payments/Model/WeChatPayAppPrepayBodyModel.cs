using System.Text.Json.Serialization;
using Essensoft.Paylinks.WeChatPay.Payments.Domain;

namespace Essensoft.Paylinks.WeChatPay.Payments.Model;

public class WeChatPayAppPrepayBodyModel
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
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 交易结束时间
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
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; }

    /// <summary>
    /// 订单优惠标记
    /// </summary>
    [JsonPropertyName("goods_tag")]
    public string? GoodsTag { get; set; }

    /// <summary>
    /// 电子发票入口开放标识
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
