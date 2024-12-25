using System.Text.Json.Serialization;
using Essensoft.Paylinks.Alipay.Core;

namespace Essensoft.Paylinks.Alipay.Payments.Notify;

/// <summary>
/// 收单退款冲退完成通知
/// </summary>
/// <para>
/// https://opendocs.alipay.com/open-v3/64342630_alipay.trade.refund.depositback.completed
/// 收单退款冲退完成通知
/// 更新时间：2023-12-26 16:58:07
/// </para>
public class AlipayTradeRefundDepositBackCompletedNotify : IAlipayNotify
{
    /// <summary>
    /// 通知ID
    /// </summary>
    [JsonPropertyName("notify_id")]
    public string NotifyId { get; set; }

    /// <summary>
    /// 消息发送时的服务端时间
    /// </summary>
    [JsonPropertyName("utc_timestamp")]
    public string UtcTimestamp { get; set; }

    /// <summary>
    /// 消息接口名称
    /// </summary>
    [JsonPropertyName("msg_method")]
    public string MsgMethod { get; set; }

    /// <summary>
    /// 消息接受方的应用id
    /// </summary>
    [JsonPropertyName("app_id")]
    public string AppId { get; set; }

    /// <summary>
    /// 版本号(1.1版本为标准消息)
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// 消息报文
    /// </summary>
    [JsonPropertyName("biz_content")]
    public string BizContent { get; set; }

    /// <summary>
    /// 签名
    /// </summary>
    [JsonPropertyName("sign")]
    public string Sign { get; set; }

    /// <summary>
    /// 签名类型
    /// </summary>
    [JsonPropertyName("sign_type")]
    public string SignType { get; set; }

    /// <summary>
    /// 编码集，该字符集为验签和解密所需要的字符集
    /// </summary>
    [JsonPropertyName("charset")]
    public string Charset { get; set; }
}
