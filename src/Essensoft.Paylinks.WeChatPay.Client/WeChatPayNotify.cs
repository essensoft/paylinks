using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.WeChatPay.Client;

/// <summary>
/// WeChatPay 通知
/// </summary>
public class WeChatPayNotify
{
    /// <summary>
    /// 通知的唯一ID。
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 通知创建时间
    /// </summary>
    [JsonPropertyName("create_time")]
    public DateTimeOffset CreateTime { get; set; }

    /// <summary>
    /// 通知类型
    /// </summary>
    [JsonPropertyName("event_type")]
    public string EventType { get; set; }

    /// <summary>
    /// 通知数据类型
    /// </summary>
    [JsonPropertyName("resource_type")]
    public string ResourceType { get; set; }

    /// <summary>
    /// 通知资源数据
    /// </summary>
    [JsonPropertyName("resource")]
    public WeChatPayNotifyResource Resource { get; set; }

    /// <summary>
    /// 回调摘要
    /// </summary>
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
}
